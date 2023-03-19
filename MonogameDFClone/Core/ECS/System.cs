using Microsoft.Xna.Framework;

namespace MonogameDFClone.Core {
    public abstract class System {
        public List<Entity> Entities = new List<Entity>();
        public virtual void Update(GameTime gameTime) {

        }
        public virtual void AddEntity(Entity entity) {
            Entities.Add(entity);
        }

        public virtual void RemoveEntity(Entity entity) {
            Entities.Remove(entity);
        }
    }
}
