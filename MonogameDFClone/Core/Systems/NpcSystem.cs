using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;

namespace MonogameDFClone.Core.Systems {
    internal sealed class NpcSystem : AEntitySetSystem<float> {
        public NpcSystem(World world, IParallelRunner _runner) : base(world, _runner) { }
        public void Update(in Entity entity, float elapsedTime, ref DrawInfo drawInfo, ref Position position) {
            drawInfo.Position = new Vector2(position.Column * Globals.TileSize, position.Row * Globals.TileSize);

        }
    }
}
