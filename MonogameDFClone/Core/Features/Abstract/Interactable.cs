using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Core.Features {
    public abstract class Interactable {
        public int Row { get; }
        public int Column { get; }
        public bool IsVisible { get; set; } = true;
        public bool IsActive { get; set; } = true;
        public Rectangle Rectangle { get; set; }
        public Color Color { get; set; }

        protected Interactable(int row, int column, Color color, bool isVisible, bool isActive) {
            Row = row;
            Column = column;
            IsVisible = isVisible;
            IsActive = isActive;
            Color = color;
        }

        public virtual void Update(GameTime gameTime, Player player) {

        }
        public virtual void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(AssetManager.Instance.Texture, GetPosition(), Rectangle, Color);
        }

        public Vector2 GetPosition() {
            return new Vector2(Column * Globals.TileSize, Row * Globals.TileSize);
        }
    }
}
