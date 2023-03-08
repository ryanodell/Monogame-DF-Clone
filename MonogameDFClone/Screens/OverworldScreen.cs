using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core.Features;
using MonogameDFClone.Core.Tiling;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Screens {
    public class OverworldScreen : ScreenBase {
        private Camera2D _worldCamera;
        private Player _player;
        private int _rows = 25;
        private int _columns = 25;
        public List<Interactable> _atSymbols = new List<Interactable>();
        private SpriteFont _spriteFont;
        public override void LoadContent() {
            Globals.Map = new GameMap(_rows, _columns);
            _player = new Player(Vector2.Zero);
            _worldCamera = new Camera2D(Globals.GameReference.GraphicsDevice);
            _worldCamera.Zoom = 2f;
            _atSymbols.Add(new AtSymbol(4, 4, Color.DarkGray, true, true));
            _atSymbols.Add(new AtSymbol(7, 2, Color.DarkGray, true, true));
            _atSymbols.Add(new AtSymbol(4, 20, Color.DarkGray, true, true));
            _atSymbols.Add(new Heart(9, 2, Color.DarkRed, true, true));
            AudioManager.Instance.PlaySong(Globals.OverWorldSongName);
            _spriteFont = Globals.GameReference.Content.Load<SpriteFont>("Resources/SDS_8x8");
        }


        public override void UnloadContent() {
            
        }

        public override void Update(GameTime gameTime) {
            InputManager.Instance.Update(gameTime);
            _player.Update(gameTime);
            foreach(var atSymbol in _atSymbols) {
                atSymbol.Update(gameTime, _player);
            }
            _worldCamera.LookAt(_player.Position);
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Globals.GameReference?.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, _worldCamera?.GetViewMatrix());
            Globals.Map.Draw(spriteBatch);
            _player.Draw(spriteBatch);
            foreach (var atSymbol in _atSymbols) {
                atSymbol.Draw(spriteBatch);
            }
            spriteBatch.DrawString(_spriteFont, "Hello Twitch", Vector2.Zero, Color.WhiteSmoke);
            spriteBatch.End();
        }
    }
}
