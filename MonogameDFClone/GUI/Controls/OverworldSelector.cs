using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;

namespace MonogameDFClone.GUI {
    public class OverworldSelector : GuiItem {
        private const int _blinkSpeed = 500;
        private int _blinkTimer = _blinkSpeed;
        public int Column;
        public int Row;
        private bool _blinking = false;
        public EventHandler<OverworldSelectorEventArgs> On_Change;
        public EventHandler<OverworldSelectorEventArgs> On_Select;

        public Vector2 Position { get {
                return new Vector2(Column * Globals.TileSize, Row * Globals.TileSize);
            } 
        }
        public OverworldSelector(bool visible, bool active) : base(visible, active) {
            Column = 0;
            Row = 0;
        }

        public OverworldSelector(bool visible, bool active, int column, int row) : base(visible, active) {
            Column = column;
            Row = row;
        }
        public override void Update(GameTime gameTime) {
            if (!Active) return;
            if (InputManager.Instance.IsInputAction(eInputAction.Right)) {
                Column++;
                Console.WriteLine($"{Column}_{Row}");
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Left)) {
                Column--;
                Console.WriteLine($"{Column}_{Row}");
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Down)) {
                Row++;
                Console.WriteLine($"{Column}_{Row}");
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Up)) {
                Row--;
                Console.WriteLine($"{Column}_{Row}");
            }
            _blinkTimer -= (int)gameTime.ElapsedGameTime.TotalMilliseconds;
            if(_blinkTimer < 0) {
                _blinking = !_blinking;
                _blinkTimer = _blinkSpeed;
            }
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            if (!Visible) return;
            if (!_blinking) {
                spriteBatch.Draw(AssetManager.Instance.Texture, Position, Globals.Rects.LargeX, Color.YellowGreen);
            }
        }
    }
}
