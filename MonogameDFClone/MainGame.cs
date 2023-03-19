using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;
using MonogameDFClone.Screens;

namespace MonogameDFClone {
    public class MainGame : Game {
        public GraphicsDeviceManager Graphics;
        public SpriteBatch spriteBatch;

        public MainGame() {
            Graphics = new GraphicsDeviceManager(this);
            Graphics.PreferMultiSampling = false;
            Graphics.SynchronizeWithVerticalRetrace = true;
            IsMouseVisible = true;
        }
        protected override void Initialize() {
            Globals.GameReference = this;
            AssetManager.Instance.Init();
            AudioManager.Mute = true;
            Graphics.PreferredBackBufferWidth = 1280;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void LoadContent() {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            ScreenManager.Instance.ChangeScreen(new SplashScreen());
        }

        protected override void UnloadContent() {
            base.UnloadContent();
        }


        protected override void Update(GameTime gameTime) {
            ScreenManager.Instance.Update(gameTime);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            ScreenManager.Instance.Draw(spriteBatch, gameTime);
        }

    }
}
