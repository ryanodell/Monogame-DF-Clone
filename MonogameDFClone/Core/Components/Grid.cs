using DefaultEcs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameDFClone.Core.Components {
    internal sealed class Grid {
        public readonly struct Enumerable : IEnumerable<List<Entity>> {
            public IEnumerator<List<Entity>> GetEnumerator() {
                throw new NotImplementedException();
            }

            IEnumerator IEnumerable.GetEnumerator() {
                throw new NotImplementedException();
            }
        }
    }
}
