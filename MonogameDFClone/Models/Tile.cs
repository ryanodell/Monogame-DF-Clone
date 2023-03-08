using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDFClone.Models {
    public class Tile {
        public Texture2D Texture { get; }
        public int Row { get; }
        public int Column { get; }
        public int Zindex { get; }
        public Rectangle SrcRect { get; }
        public Color Color { get; }
        public Tile(Texture2D texture, int row, int column, int zindex, Rectangle srcRect, Color color) {
            Texture = texture;
            Row = row;
            Column = column;
            Zindex = zindex;
            SrcRect = srcRect;
            Color = color;
        }

        public void Update(GameTime gameTime) {

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            spriteBatch.Draw(Texture, new Vector2(Row * Globals.TileSize, Column * Globals.TileSize), SrcRect, Color);
        }

    }
}
