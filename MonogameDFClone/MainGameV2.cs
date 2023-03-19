using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core;
using MonogameDFClone.Core.Systems;
using MonogameDFClone.Managers;
using MonogameDFClone.Screens;

namespace MonogameDFClone {
    public class MainGameV2 : Game {
        private GraphicsDeviceManager _deviceManager;
        SpriteBatch _spriteBatch;
        private World _world;

        private readonly DefaultParallelRunner _runner;
        private readonly ISystem<SpriteBatch> _drawSystem;

        public MainGameV2() {
            _deviceManager = new GraphicsDeviceManager(this);
            _deviceManager.PreferMultiSampling = false;
            _deviceManager.SynchronizeWithVerticalRetrace = true;
            _deviceManager.PreferredBackBufferWidth = 1280;
            _deviceManager.PreferredBackBufferHeight = 720;
            _deviceManager.ApplyChanges();
            IsMouseVisible = true;
            _runner = new DefaultParallelRunner(Environment.ProcessorCount);


        }
        //protected override void Initialize() {
        //    _deviceManager.PreferredBackBufferWidth = 1280;
        //    _deviceManager.PreferredBackBufferHeight = 720;
        //    _deviceManager.ApplyChanges();
        //    base.Initialize();
        //}
        protected override void LoadContent() {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            _world = new World();
            //_drawSystem = new DrawSystem(_world, Content.Load<Texture2D>("Resources/kruggsmash"))
        }

        protected override void UnloadContent() {
            base.UnloadContent();
        }


        protected override void Update(GameTime gameTime) {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime) {
            GraphicsDevice.Clear(Color.Red);
            _drawSystem.Update(_spriteBatch);
        }

    }
}
