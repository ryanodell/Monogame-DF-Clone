using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Core.Systems {
    internal sealed class PlayerSystem : AEntitySetSystem<float> {
        public PlayerSystem(World world, IParallelRunner _runner) 
            : base(world.GetEntities().With<PlayerInput>().With<Position>().AsSet(), _runner) { }
        protected override void Update(float state, in Entity entity) {
            ref Position position = ref entity.Get<Position>();
            if (InputManager.Instance.IsInputAction(eInputAction.Right)) {
                position.Column++;
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Left)) {
                position.Column--;
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Down)) {
                position.Row++;
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Up)) {
                position.Row--;
            }
        }
    }
}
