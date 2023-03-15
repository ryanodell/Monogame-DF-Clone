using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDFClone.Core.Tiling {
    public class GameCell {

        public int Size { get; set; }
        public Vector2 Position { get { return new Vector2(Row * Globals.TileSize, Column * Globals.TileSize); } }
        public List<GameTile> Tiles { get; set; } = new List<GameTile>();
        public bool Walkable() => Tiles.All(x => x.Walkable);

        public int Row { get; }
        public int Column { get; }

        public int GScore { get; set; }
        public int FScore { get; set; }
        public GameCell Parent;

        public GameCell(int row, int column) {
            Row = row;
            Column = column;
        }

        public void AddTile(GameTile tile) {
            Tiles.Add(tile);
        }

        public string Idx {
            get {
                return $"{(int)(Math.Ceiling((decimal)(Position.X / Globals.TileSize)))}" +
                    $"_{(int)(Math.Ceiling((decimal)(Position.Y / Globals.TileSize)))}";
            }
        }

        public void Update(GameTime gameTime) {

        }

        public void Draw(SpriteBatch spriteBatch) {
            foreach(GameTile tile in Tiles) {
                tile.Draw(spriteBatch, this);
            }
        }
    }
}
