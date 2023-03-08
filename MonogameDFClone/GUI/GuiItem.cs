using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDFClone.GUI {
    public class GuiItem {
        public bool Visible;
        public bool Active;

        public GuiItem(bool visible, bool active) {
            Visible = visible;
            Active = active;
        }

        public virtual void Update(GameTime gameTime) {

        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime) {

        }
    }
}
