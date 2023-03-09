using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;
using MonogameDFClone.Models;

namespace MonogameDFClone.GUI {
    public class KeyboardMenu : GuiItem {

        public EventHandler<KeyboardMenuEventArgs> On_KeyMenuItemSelected;
        public List<KeyboardMenuItem> MenuKeys;
        private SpriteFont _spriteFont = Globals.GameReference.Content.Load<SpriteFont>("Resources/SDS_8x8");
        public KeyboardMenu(bool visible, bool active) : base(visible, active) {
            MenuKeys = new List<KeyboardMenuItem>();
        }

        public KeyboardMenu(bool visible, bool active, List<KeyboardMenuItem> menuItems) 
            : base(visible, active) {
            MenuKeys = menuItems;
        }

        public override void Update(GameTime gameTime) {
            if (!Active) return;
            foreach(var key in MenuKeys) {
                if(InputManager.Instance.IsKeyPressed(key.Key)) {
                    On_KeyMenuItemSelected.Invoke(this, new KeyboardMenuEventArgs(key));
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            if (!Visible) return;
            foreach(var item in MenuKeys) {
                spriteBatch.DrawString(_spriteFont, $"{item.OverrideChar} - {item.Text}", Vector2.Zero, Color.Blue);
            }
        }
    }
}
