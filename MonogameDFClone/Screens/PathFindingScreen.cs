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
        List<GameCell> _path = new List<GameCell>();
        List<GameCell> _currentNeighbors = new List<GameCell>();
        GameCell _startingNode = null;
        GameCell _goalNode = null;
        public override void LoadContent() {
            Globals.Map = new GameMap(_rows, _columns);
            _worldCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _worldCamera.Zoom = 2f;
            _overWorldSelector = new OverworldSelector(true, true);
            _guiCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _guiCamera.Zoom = 1f;
            List<KeyboardMenuItem> menuItems = new List<KeyboardMenuItem>();
            menuItems.Add(new KeyboardMenuItem(Keys.A, "Toggle Selector"));
            menuItems.Add(new KeyboardMenuItem(Keys.B, "Set Start Node"));
            menuItems.Add(new KeyboardMenuItem(Keys.C, "Set End Node"));
            menuItems.Add(new KeyboardMenuItem(Keys.D, "Calculate Path"));
            menuItems.Add(new KeyboardMenuItem(Keys.E, "Generate New Map"));
            menuItems.Add(new KeyboardMenuItem(Keys.F, "Generate Neighbors"));
            menuItems.Add(new KeyboardMenuItem(Keys.G, "Toggle Diaganol"));
            menuItems.Add(new KeyboardMenuItem(Keys.X, "Clear"));
            _keyboardMenu = new KeyboardMenu(true, true, menuItems);
            _keyboardMenu.On_KeyMenuItemSelected += OnKeyboardMenuSelect;
            _guiCamera.LookAt(new Vector2(Globals.GameReference.Graphics.PreferredBackBufferWidth / 2, Globals.GameReference.Graphics.PreferredBackBufferHeight / 2));
        }

        protected void OnKeyboardMenuSelect(object sender, KeyboardMenuEventArgs args) {
            if(args.SelectedMenu.Key == Keys.A) {
                _overWorldSelector.Visible = !_overWorldSelector.Visible;
            }
            if(args.SelectedMenu.Key == Keys.B) {
                _startingNode = Globals.Map.Cells[$"{_overWorldSelector.Column}_{_overWorldSelector.Row}"];
            }
            if (args.SelectedMenu.Key == Keys.C) {
                _goalNode = Globals.Map.Cells[$"{_overWorldSelector.Column}_{_overWorldSelector.Row}"];
            }
            if (args.SelectedMenu.Key == Keys.D) {
                if (_startingNode != null && _goalNode != null) {
                    _path = PathingManager.Instance.FindPath(_startingNode, _goalNode);
                }
            }
            if (args.SelectedMenu.Key == Keys.E) {
                Globals.Map = new GameMap(_rows, _columns);
            }
            if (args.SelectedMenu.Key == Keys.F) {
                Console.WriteLine($"Current: {Globals.Map.Cells[$"{_overWorldSelector.Column}_{_overWorldSelector.Row}"].Idx}");
                var neighbors = PathingManager.Instance._getNeighbors(Globals.Map.Cells[$"{_overWorldSelector.Column}_{_overWorldSelector.Row}"]);
                _currentNeighbors.Clear();
                _currentNeighbors = neighbors;
            }
            if (args.SelectedMenu.Key == Keys.G) {
                PathingManager.Instance.Diagonal = !PathingManager.Instance.Diagonal;
                Console.WriteLine($"Allow Diagonal: {PathingManager.Instance.Diagonal}");
            }
            if (args.SelectedMenu.Key == Keys.X) {
                _path.Clear();
                _currentNeighbors.Clear();
                _startingNode = null;
                _goalNode = null;
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
            if (_path != null) {
                foreach (var item in _path) {
                    spriteBatch.Draw(AssetManager.Instance.Texture, item.Position, Globals.Rects.LargeX, Color.Orange);
                }
            }
            if(_startingNode != null) {
                spriteBatch.Draw(AssetManager.Instance.Texture, _startingNode.Position, Globals.Rects.Heart, Color.Blue);
            }
            if (_goalNode != null) {
                spriteBatch.Draw(AssetManager.Instance.Texture, _goalNode.Position, Globals.Rects.Heart, Color.Green);
            }
            foreach (var neighbor in _currentNeighbors) {
                spriteBatch.Draw(AssetManager.Instance.Texture, neighbor.Position, Globals.Rects.LargeX, Color.Red);
            }
            spriteBatch.End();

            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _guiCamera?.GetViewMatrix());
            _keyboardMenu.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}
