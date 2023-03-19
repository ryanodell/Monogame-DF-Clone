using DefaultEcs;
using DefaultEcs.System;
using DefaultEcs.Threading;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameDFClone.Core.Systems {
    public class PositionSystem : AEntitySetSystem<float> {
        public PositionSystem(World world, IParallelRunner runner) : base(world, runner) { }

        protected override void Update(float state, in Entity entity) {

        }

    }
}
