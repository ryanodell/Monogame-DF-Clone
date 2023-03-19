using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;


namespace MonogameDFClone.Core.Systems {
    public class PositionSystem : AEntitySetSystem<float> {
        public PositionSystem(World world, IParallelRunner runner) : base(world.GetEntities().With<Position>().With<DrawInfo>().AsSet(), runner) { }

        protected override void Update(float state, in Entity entity) {
            var pos = entity.Get<Position>();
            ref DrawInfo drawInfo = ref entity.Get<DrawInfo>();
            drawInfo.Position = new Vector2(pos.Column * Globals.TileSize, pos.Row * Globals.TileSize);
        }

    }
}
