using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Forms.Controls;
using Color = Microsoft.Xna.Framework.Color;
using MouseEventArgs = System.Windows.Forms.MouseEventArgs;
using MouseButtons = System.Windows.Forms.MouseButtons;
using System;
using System.Collections.Generic;
using MonogameDFClone.Shared;

namespace MonogameDFClone {
    public class SpriteSheetRenderer : MonoGameControl {
        private const int _tileSize = 16;
        private const float _cameraZoomSpeed = 0.3f;
        private bool _camMouseDown = false;
        private Point _camDragPosition;
        private Rectangle _selectorRect = new Rectangle(0, 0, 16, 16);
        private Texture2D _selector;
        private Texture2D _texture;
        private ContentManager _content;
        private MouseState _previousMouseState;

        public event EventHandler OnSelect;
        public IDictionary<string, SpriteSheetTile> SpriteSheetTiles = new Dictionary<string, SpriteSheetTile>();
        protected override void Initialize() {
            base.Initialize();
            OnMouseWheelDownwards += SpriteSheetRenderer_OnMouseWheelDown;
            OnMouseWheelUpwards += SpriteSheetRenderer_OnMouseWheelUp;
            _content = new ContentManager(Services, "Resources");
            //_texture = _content.Load<Texture2D>("spritesheet");
            _texture = _content.Load<Texture2D>("kruggsmash");
            _selector = new Texture2D(GraphicsDevice, 1, 1);
            _selector.SetData(new Color[] { Color.Red });
        }

        public void SetData(IDictionary<string, SpriteSheetTile> data) {
            SpriteSheetTiles = data;
        }

        protected override void Update(GameTime gameTime) {
            base.Update(gameTime);
            if (IsMouseInsideControl) {
                MouseState mState = Mouse.GetState();
                if (mState.LeftButton == ButtonState.Released && _previousMouseState.LeftButton == ButtonState.Pressed) {
                    var mouseTransform = Vector2.Transform(new Vector2(Editor.GetRelativeMousePosition.X, 
                        Editor.GetRelativeMousePosition.Y), Matrix.Invert(Editor.Cam.Transform));
                    var column = (int)Math.Ceiling(mouseTransform.X / _tileSize) - 1;
                    var row = (int)Math.Ceiling(mouseTransform.Y / _tileSize) - 1;
                    SpriteSheetTiles.TryGetValue($"{column}_{row}", out var tile);
                    if (tile != null) {
                        _selectorRect = new Rectangle(column * _tileSize, row * _tileSize, _tileSize, _tileSize);
                        EventHandler handler = OnSelect;
                        handler?.Invoke(tile, new EventArgs());
                    }
                }
                _previousMouseState = mState;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e) {
            if(e.Button == MouseButtons.Middle) {
                _camMouseDown = true;
                _camDragPosition = new Point(e.X, e.Y);
            }
            base.OnMouseDown(e);
        }

        protected override void OnMouseMove(MouseEventArgs e) {
            if(_camMouseDown) {
                int xDiff = _camDragPosition.X - e.Location.X;
                int yDiff = _camDragPosition.Y - e.Location.Y;
                Editor.MoveCam(new Vector2(xDiff, yDiff));
                _camDragPosition.X = e.Location.X;
                _camDragPosition.Y = e.Location.Y;
            }
            base.OnMouseMove(e);
        }

        protected override void OnMouseUp(MouseEventArgs e) {
            _camMouseDown = false;
            base.OnMouseUp(e);
        }

        protected void SpriteSheetRenderer_OnMouseWheelUp(MouseEventArgs e) {
            Editor.Cam.Zoom += _cameraZoomSpeed;
        }

        protected void SpriteSheetRenderer_OnMouseWheelDown(MouseEventArgs e) {
            Editor.Cam.Zoom -= _cameraZoomSpeed;
        }

        protected override void Draw() {
            GraphicsDevice.Clear(Color.Black);
            Editor.BeginCamera2D(SpriteSortMode.Immediate, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null);
            Editor.spriteBatch.Draw(_texture, Vector2.Zero, null, Color.White);
            DrawSelectionBox(_selectorRect);
            Editor.EndCamera2D();
        }

        private void DrawSelectionBox(Rectangle rect) {
            const int t = 1;
            Rectangle rect1 = new Rectangle(rect.X, rect.Y, t, rect.Height);
            Rectangle rect2 = new Rectangle(rect.X, rect.Y + rect.Height - t, rect.Width, t);
            Rectangle rect3 = new Rectangle(rect.X + rect.Width - t, rect.Y, t, rect.Height);
            Rectangle rect4 = new Rectangle(rect.X, rect.Y, rect.Width, t);
            Color color = Color.Red;

            Editor.spriteBatch.Draw(_selector, rect1, color);
            Editor.spriteBatch.Draw(_selector, rect2, color);
            Editor.spriteBatch.Draw(_selector, rect3, color);
            Editor.spriteBatch.Draw(_selector, rect4, color);
        }
    }
}
