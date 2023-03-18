using MonogameDFClone.Core.Tiling;

namespace MonogameDFClone.Managers {
    public class PathingManager {
        private static PathingManager _instance;
        public static PathingManager Instance {
            get {
                if (_instance == null) {
                    _instance = new PathingManager();
                }
                return _instance;
            }
        }

        public List<GameCell> FindPath(GameCell startingNode, GameCell goalNode) {
            _setNeighbors();
            List<GameCell> openSet = new List<GameCell>();
            openSet.Add(startingNode);
            Dictionary<GameCell, int> gScore = new Dictionary<GameCell, int> {
                [startingNode] = 0
            };
            Dictionary<GameCell, int> fScore = new Dictionary<GameCell, int> {
                [startingNode] = _heuristic(startingNode, goalNode)
            };
            while(openSet.Count > 0) {
                GameCell current = null;
                int lowestFScore = int.MaxValue;
                foreach(GameCell node in openSet) {
                    if(fScore[node] < lowestFScore) {
                        current = node;
                        lowestFScore = fScore[node];
                    }
                }
                if(current == goalNode) {
                    return _reconstructPath(current);
                }
                openSet.Remove(current);
                //foreach (GameCell neighbor in _getNeighbors(current)) {
                foreach (GameCell neighbor in current.Neighbors) {
                    int tentativeGScore = gScore[current] + 1;
                    if (tentativeGScore < gScore.GetValueOrDefault(neighbor, int.MaxValue)) {
                        neighbor.Parent = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = tentativeGScore + _heuristic(neighbor, goalNode);
                        if (!openSet.Contains(neighbor)) {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }
            return null;
        }

        private List<GameCell> _reconstructPath(GameCell current) {
            List<GameCell> path = new List<GameCell>();
            while(current != null) {
                path.Add(current);
                current = current.Parent;
            }
            path.Reverse();
            return path;
        }

        private void _setNeighbors() {
            foreach(var item in Globals.Map.Cells) {
                item.Value.Neighbors = _getNeighbors(item.Value);
            }
        }


        public List<GameCell> _getNeighbors(GameCell current) {
            List<GameCell> returnValue = new List<GameCell>();
            int row = current.Row;
            int col = current.Column;
            if(Globals.Map.Cells.TryGetValue($"{col + 1}_{row}", out var cellToTheRight)) {
                if(cellToTheRight.Walkable()) {
                    returnValue.Add(cellToTheRight);
                }
            }
            if (Globals.Map.Cells.TryGetValue($"{col - 1}_{row}", out var cellToTheLeft)) {
                if (cellToTheLeft.Walkable()) {
                    returnValue.Add(cellToTheLeft);
                }
            }
            if (Globals.Map.Cells.TryGetValue($"{col}_{row - 1}", out var cellToTheTop)) {
                if (cellToTheTop.Walkable()) {
                    returnValue.Add(cellToTheTop);
                }
            }
            if (Globals.Map.Cells.TryGetValue($"{col}_{row + 1}", out var cellToTheBottom)) {
                if (cellToTheBottom.Walkable()) {
                    returnValue.Add(cellToTheBottom);
                }
            }
            return returnValue;
        }

        private int _heuristic(GameCell a, GameCell b) {
            return Math.Abs(a.Column - b.Column) + Math.Abs(a.Row - b.Row);
        }
    }
}
