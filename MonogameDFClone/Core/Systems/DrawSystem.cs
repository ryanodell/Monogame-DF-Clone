using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core.Features;

namespace MonogameDFClone.Core.Systems {
    public class DrawSystem : AComponentSystem<SpriteBatch, DrawInfo> {
        private readonly World _world;
        private readonly Texture2D _texture;
        private readonly Camera2D _camera;
        private readonly IParallelRunner _runner;
        public DrawSystem(World world, Texture2D texture, Camera2D camera) : base(world) {
            _world = world;
            _texture = texture;
            _camera = camera;
            _runner = world.Get<IParallelRunner>();
        }
        protected override void PreUpdate(SpriteBatch state) => state.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend,
            SamplerState.PointClamp, null, null, null, _camera.GetViewMatrix());
        protected override void Update(SpriteBatch state, Span<DrawInfo> components) {
            foreach(ref DrawInfo component in components) {
                state.Draw(_texture, component.Position, component.SourceRectangle, component.Color);
            }
        }
        protected override void PostUpdate(SpriteBatch state) => _world.Optimize(_runner, state.End);


    }
}
