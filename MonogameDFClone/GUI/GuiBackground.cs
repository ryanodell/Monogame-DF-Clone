using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDFClone.GUI {
    public class GuiBackground : GuiItem {
        public Vector2 Position;
        public Rectangle Rect;
        Texture2D pixelData;
        public GuiBackground(bool visible, bool active) : base(visible, active) {
            Position = Vector2.Zero;
            Rect = Rectangle.Empty;
            pixelData = new Texture2D(Globals.GameReference.GraphicsDevice, 1, 1);
            pixelData.SetData<Color>(new Color[] { Color.Black });
        }

        public GuiBackground(bool visible, bool active, Vector2 position, Rectangle rect) : base(visible, active) {
            Position = position;
            Rect = rect;
            pixelData = new Texture2D(Globals.GameReference.GraphicsDevice, 1, 1);
            pixelData.SetData<Color>(new Color[] { Color.Black });
        }
        public override void Update(GameTime gameTime) {
            if (!Active) return;
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            if (!Visible) return;

            spriteBatch.Draw(pixelData, Position, Rect, Color.Black);

        }
    }
}
