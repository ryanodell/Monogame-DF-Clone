using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonogameDFClone.Core {
    public class Entity : IEquatable<Entity> {

        private readonly IDictionary<Type, Component> _components = new Dictionary<Type, Component>();

        public void AddComponent<T>(T component) where T : Component {
            _components[typeof(T)] = component;
        }

        public void RemoveComponent<T>() where T : Component {
            _components.Remove(typeof(T));
        }

        public T? GetComponent<T>() where T : Component {
            return _components.TryGetValue(typeof(T), out Component component) ? component as T : null;
        }

        public bool Equals(Entity obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Entity)obj);
        }

        public static bool operator ==(Entity left, Entity right) {
            return Equals(left, right);
        }

        public static bool operator !=(Entity left, Entity right) {
            return !Equals(left, right);
        }
    }
}
