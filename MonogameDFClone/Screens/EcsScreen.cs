using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core;
using MonogameDFClone.Core.Features;
using MonogameDFClone.Core.Systems;

namespace MonogameDFClone.Screens {
    public class EcsScreen : ScreenBase {
        private Camera2D _worldCamera;
        private readonly World _world;
        private readonly DefaultParallelRunner _runner;
        private readonly ISystem<SpriteBatch> _drawSystem;
        private readonly ISystem<float> _system;

        public EcsScreen() {
            _runner = new DefaultParallelRunner(Environment.ProcessorCount);
            _worldCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _world = new World();
            _world.Set<IParallelRunner>(_runner);
            _system = new SequentialSystem<float>(
                new MoveSystem(_world, _runner)
            );
            _drawSystem = new DrawSystem(_world, Globals.GameReference.Content.Load<Texture2D>("Resources/kruggsmash"), _worldCamera);

        }

        public override void LoadContent() {
            Entity entity = _world.CreateEntity();
            entity.Set(new DrawInfo { 
                Color = Color.White, 
                SourceRectangle = Globals.Rects.Dwarf1 }
            );
            entity.Set(new Position {
                Column = 0,
                Row = 0
            });
            _world.Optimize();
        }

        public override void Update(GameTime gameTime) {
            _system.Update((float)gameTime.ElapsedGameTime.TotalMilliseconds);
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Globals.GameReference.GraphicsDevice.Clear(Color.Black);
            _drawSystem.Update(spriteBatch);
        }
        public override void UnloadContent() {
            _runner.Dispose();
            _world.Dispose();
            _drawSystem.Dispose();
            _system.Dispose();
        }
    }
}
