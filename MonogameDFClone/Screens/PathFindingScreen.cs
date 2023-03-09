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
        private GuiBackground _guiBackground;
        private KeyboardMenu _keyboardMenu;

        public override void LoadContent() {
            Globals.Map = new GameMap(_rows, _columns);
            _worldCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _worldCamera.Zoom = 2f;
            _overWorldSelector = new OverworldSelector(true, true);
            _guiBackground = new GuiBackground(true, true, Vector2.Zero, new Rectangle(0, 0, Globals.GameReference.Graphics.PreferredBackBufferWidth, 275));
            _guiCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _guiCamera.Zoom = 3f;
            List<KeyboardMenuItem> menuItems = new List<KeyboardMenuItem>();
            menuItems.Add(new KeyboardMenuItem(Keys.A, "Toggle Selector"));
            menuItems.Add(new KeyboardMenuItem(Keys.B, "Test"));
            _keyboardMenu = new KeyboardMenu(true, true, menuItems);
            _keyboardMenu.On_KeyMenuItemSelected += OnKeyboardMenuSelect;
            _guiCamera.LookAt(new Vector2(Globals.GameReference.Graphics.PreferredBackBufferWidth / 2, Globals.GameReference.Graphics.PreferredBackBufferHeight / 2));
        }

        protected void OnKeyboardMenuSelect(object sender, KeyboardMenuEventArgs args) {
            var test = args.SelectedMenu.Text;
            Console.WriteLine(test);
        }

        public override void UnloadContent() {
            _keyboardMenu.On_KeyMenuItemSelected -= OnKeyboardMenuSelect;
        }

        public override void Update(GameTime gameTime) {
            InputManager.Instance.Update(gameTime);
            _overWorldSelector.Update(gameTime);
            _worldCamera.LookAt(_overWorldSelector.Position);
            //_guiCamera.LookAt(new Vector2(Globals.GameReference.Graphics.PreferredBackBufferWidth / 2, Globals.GameReference.Graphics.PreferredBackBufferHeight / 2));
            _keyboardMenu.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Globals.GameReference?.GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _worldCamera?.GetViewMatrix());
            Globals.Map.Draw(spriteBatch);
            _overWorldSelector.Draw(spriteBatch, gameTime);            
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _guiCamera?.GetViewMatrix());
            _guiBackground.Draw(spriteBatch, gameTime);
            _keyboardMenu.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}
