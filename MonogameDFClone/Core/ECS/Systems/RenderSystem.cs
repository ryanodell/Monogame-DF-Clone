using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core.Features;

namespace MonogameDFClone.Core.ECS.Systems {
    public class RenderSystem : System {
        private Camera2D _camera;
        public GraphicsDevice _graphicsDevice;

        public RenderSystem(GraphicsDevice graphicDevice, Camera2D camera) {
            _graphicsDevice = graphicDevice;
            _camera = camera;
        }

        public override void Update(GameTime gameTime) {
        }

        public void Draw(SpriteBatch spriteBatch) {
            _graphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _camera.GetViewMatrix());
            foreach (var entity in Entities) {
                var sprite = entity.GetComponent<SpriteComponent>();
                if (sprite != null) {
                    spriteBatch.Draw(sprite.Texture, sprite.Position, sprite.SourceRectangle, sprite.Color);
                }
            }
            spriteBatch.End();
        }

    }
}
