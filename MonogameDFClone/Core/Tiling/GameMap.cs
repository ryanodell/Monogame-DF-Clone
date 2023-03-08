using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDFClone.Core.Tiling {
    public class GameMap {
        public static Random _rnd = new Random();
        public int TotalColumns { get; private set; }
        public int TotalRows { get; private set; }
        public GameMap(int rows, int columns) {
            TotalRows = rows;
            TotalColumns = columns;
            for (int y = 0; y < TotalColumns; y++) {
                for (int x = 0; x < TotalRows; x++) {
                    var cell = new GameCell(x, y);
                    int chanceOfTree = _rnd.Next(6);
                    if (chanceOfTree == 0) {
                        cell.AddTile(new GameTile(Globals.Rects.Tree, false, 1, Color.DarkRed));
                    } else {
                        cell.AddTile(new GameTile(Globals.Rects.Grass, true, 1, Color.DarkGreen));                        
                    }
                    Cells.Add($"{x}_{y}", cell);
                }
            }
        }
        public IDictionary<string, GameCell> Cells { get; set; } = new Dictionary<string, GameCell>();

        public bool IsCellWalkable(int column, int row) {
            if(Cells.TryGetValue($"{column}_{row}", out var currentCell)) {
                return currentCell.Walkable();
            }
            return false;
        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(GameCell cell in Cells.Values) {
                cell.Draw(spriteBatch);
            }
        }
    }
}
