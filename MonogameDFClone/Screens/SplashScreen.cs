using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core.Features;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Screens {
    public class SplashScreen : ScreenBase {
        private Camera2D? _camera;
        private double _duration = 100;
        private Texture2D? _texture;
        private Vector2 _position = new Vector2(100, 100);
        public override void LoadContent() {
            _texture = Globals.GameReference?.Content.Load<Texture2D>("Resources/DFClone");
            if(Globals.GameReference?.GraphicsDevice == null) {
                throw new Exception("Graphics Device could not be detected");
            }
            _camera = new Camera2D(Globals.GameReference.GraphicsDevice) {
                Zoom = 2f
            };
            _camera.LookAt(_position + new Vector2(170, 50));
        }
        public override void UnloadContent() {
            _texture?.Dispose();
        }
        public override void Update(GameTime gameTime) {
            InputManager.Instance.Update(gameTime);
            _duration -= gameTime.ElapsedGameTime.TotalMilliseconds;            
            if(_duration > 0 && !InputManager.Instance.IsInputAction(eInputAction.Select)) {
                return;
            }
            ScreenManager.Instance.ChangeScreen(new MainMenu());
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Globals.GameReference?.GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.LinearClamp, null, null, null, _camera?.GetViewMatrix());
            spriteBatch.Draw(_texture, _position, Color.White);
            spriteBatch.End();            
        }
    }
}
