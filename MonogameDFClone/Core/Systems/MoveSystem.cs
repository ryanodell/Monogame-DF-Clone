using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameDFClone.Core.Systems {
    internal sealed partial class MoveSystem : AEntitySetSystem<float> {
        public MoveSystem(World world, IParallelRunner _runner) : base(world, _runner) { }
        public void Update(in Entity entity, float elapsedTime, ref DrawInfo drawInfo, ref Position position) {
            drawInfo.Position = new Vector2(position.Column * Globals.TileSize, position.Row * Globals.TileSize);

        }
    }
}
