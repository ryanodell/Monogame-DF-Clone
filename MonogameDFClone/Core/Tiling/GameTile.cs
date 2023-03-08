using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Core.Tiling {
    public class GameTile {
        public Rectangle Rect { get; set; }
        public bool Walkable { get; set; }
        public int Zindex { get; }
        public Color Color { get; }
        public GameTile(Rectangle rect, bool walkable, int zindex, Color color) {
            Rect = rect;
            Walkable = walkable;
            Zindex = zindex;
            Color = color;
        }


        public void Update(GameTime gameTime) {

        }

        public void Draw(SpriteBatch spriteBatch, GameCell cell) {
            spriteBatch.Draw(AssetManager.Instance.Texture, new Vector2(cell.Row * Globals.TileSize, 
                cell.Column * Globals.TileSize), Rect, Color);
        }
    }
}
