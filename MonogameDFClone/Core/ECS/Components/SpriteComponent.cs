using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDFClone.Core.ECS {
    public class SpriteComponent : Component {
        public Texture2D Texture;
        public Rectangle SourceRectangle;
        public Color Color;
        public Vector2 Position;
        public float Rotation;
        public float Scale;
        public SpriteEffect Effects;
        public float LayerDepth;

        public SpriteComponent(Texture2D texture, Rectangle sourceRectangle, Color color, Vector2 position, float rotation, float scale, SpriteEffect effects, float layerDepth) {
            Texture = texture;
            SourceRectangle = sourceRectangle;
            Color = color;
            Position = position;
            Rotation = rotation;
            Scale = scale;
            Effects = effects;
            LayerDepth = layerDepth;
        }
    }
}
