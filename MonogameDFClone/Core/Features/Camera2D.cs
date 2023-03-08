using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace MonogameDFClone.Core.Features {
    public class Camera2D {
        public Vector2 Position;
        public Vector2 Origin { get; set; }
        public float Zoom { get; set; }
        public float Rotation { get; set; }
        private GraphicsDevice _graphicsDevice;

        public Camera2D(GraphicsDevice graphicsDevice) {
            _graphicsDevice = graphicsDevice;
            Rotation = 0;
            Zoom = 1;
            Origin = new Vector2(_graphicsDevice.Viewport.Width / 2f, graphicsDevice.Viewport.Height / 2f);
            Position = Vector2.Zero;
        }

        public void Move(Vector2 direction) {
            Position += Vector2.Transform(direction, Matrix.CreateRotationZ(-Rotation));
        }

        public void LookAt(Vector2 position) {
            Position = position - new Vector2(_graphicsDevice.Viewport.Width / 2f, _graphicsDevice.Viewport.Height / 2f);
        }

        public Matrix GetViewMatrix() {
            return 
                Matrix.CreateTranslation(new Vector3(-Position, 0.0f)) * 
                Matrix.CreateTranslation(new Vector3(-Origin, 0.0f)) *
                Matrix.CreateRotationZ(Rotation) *
                Matrix.CreateScale(Zoom, Zoom, 1) *
                Matrix.CreateTranslation(new Vector3(Origin, 0.0f));
        }
    }
}
