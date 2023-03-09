using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core.Features;
using MonogameDFClone.Core.Tiling;
using MonogameDFClone.GUI;
using MonogameDFClone.Managers;
using MonogameDFClone.Models;
using Microsoft.Xna.Framework.Input;

namespace MonogameDFClone.Screens {
    public class PathFindingScreen : ScreenBase {
        private Camera2D _worldCamera;
        private Camera2D _guiCamera;
        private int _rows = 100;
        private int _columns = 100;
        private OverworldSelector _overWorldSelector;
        private KeyboardMenu _keyboardMenu;

        public override void LoadContent() {
            Globals.Map = new GameMap(_rows, _columns);
            _worldCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _worldCamera.Zoom = 2f;
            _overWorldSelector = new OverworldSelector(true, true);
            _guiCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _guiCamera.Zoom = 1f;
            List<KeyboardMenuItem> menuItems = new List<KeyboardMenuItem>();
            menuItems.Add(new KeyboardMenuItem(Keys.A, "Toggle Selector"));
            menuItems.Add(new KeyboardMenuItem(Keys.B, "Test Thing"));
            menuItems.Add(new KeyboardMenuItem(Keys.C, "Buildings"));

            menuItems.Add(new KeyboardMenuItem(Keys.D, "Gross stuff"));
            menuItems.Add(new KeyboardMenuItem(Keys.E, "Exit"));
            menuItems.Add(new KeyboardMenuItem(Keys.F, "I said I don't want it right now"));

            menuItems.Add(new KeyboardMenuItem(Keys.G, "REDUX"));
            _keyboardMenu = new KeyboardMenu(true, true, menuItems);
            _keyboardMenu.On_KeyMenuItemSelected += OnKeyboardMenuSelect;
            _guiCamera.LookAt(new Vector2(Globals.GameReference.Graphics.PreferredBackBufferWidth / 2, Globals.GameReference.Graphics.PreferredBackBufferHeight / 2));
        }

        protected void OnKeyboardMenuSelect(object sender, KeyboardMenuEventArgs args) {
            if(args.SelectedMenu.Key == Keys.A) {
                _overWorldSelector.Visible = !_overWorldSelector.Visible;
            }
        }

        public override void UnloadContent() {
            _keyboardMenu.On_KeyMenuItemSelected -= OnKeyboardMenuSelect;
        }

        public override void Update(GameTime gameTime) {
            InputManager.Instance.Update(gameTime);
            _overWorldSelector.Update(gameTime);
            _worldCamera.LookAt(_overWorldSelector.Position);
            _keyboardMenu.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Globals.GameReference?.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _worldCamera?.GetViewMatrix());
            Globals.Map.Draw(spriteBatch);
            _overWorldSelector.Draw(spriteBatch, gameTime);            
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _guiCamera?.GetViewMatrix());
            _keyboardMenu.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}
