using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;
using MonogameDFClone.Models;

namespace MonogameDFClone.GUI {
    public class KeyboardMenu : GuiItem {
        
        public EventHandler<KeyboardMenuEventArgs> On_KeyMenuItemSelected;
        public List<KeyboardMenuItem> MenuKeys;
        protected const int distanceBetween = 2;
        private SpriteFont _spriteFont = Globals.GameReference.Content.Load<SpriteFont>("Resources/SDS_8x8");
        private GuiBackground _guiBackground;        
        private Memory<KeyboardMenuItem>[] _memoryChunks;
        public KeyboardMenu() : this(true, true) { }
        public KeyboardMenu(bool visible, bool active) : this(visible, active, new List<KeyboardMenuItem>()) { }
        public KeyboardMenu(List<KeyboardMenuItem> menuItems) : this(true, true, menuItems) { }

        public KeyboardMenu(List<KeyboardMenuItem> menuItems, int colSize) : this(true, true, menuItems, colSize) { }

        public KeyboardMenu(bool visible, bool active, List<KeyboardMenuItem> menuItems, int colSize = 3)
            : base(visible, active) {
            _guiBackground = new GuiBackground(true, true, Vector2.Zero, new Rectangle(0, 0, Globals.GameReference.Graphics.PreferredBackBufferWidth, 3 * Globals.TileSize + Globals.TileSize / 2));
            MenuKeys = menuItems;
            _guiBackground = new GuiBackground(true, true, Vector2.Zero, new Rectangle(0, 0, Globals.GameReference.Graphics.PreferredBackBufferWidth, 3 * Globals.TileSize + Globals.TileSize / 2));
            _chunkOutMenu(colSize);
        }

        private void _chunkOutMenu(int colSize) {
            int numChunks = (int)Math.Ceiling((double)MenuKeys.Count / colSize);
            Memory<KeyboardMenuItem> memory;
            memory = MenuKeys.ToArray().AsMemory();
            _memoryChunks = new Memory<KeyboardMenuItem>[numChunks];
            for (int i = 0; i < numChunks; i++) {
                int start = i * colSize;
                int length = Math.Min(colSize, MenuKeys.Count - start);
                _memoryChunks[i] = memory.Slice(start, length);
            }
        }

        public override void Update(GameTime gameTime) {
            if (!Active) return;
            foreach (var key in MenuKeys) {
                if (InputManager.Instance.IsKeyPressed(key.Key)) {
                    On_KeyMenuItemSelected.Invoke(this, new KeyboardMenuEventArgs(key));
                }
            }
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            if (!Visible) return;
            _guiBackground.Draw(spriteBatch, gameTime);
            _drawKeyboardOptions(spriteBatch);
        }

        private void _drawKeyboardOptions(SpriteBatch spriteBatch) {
            int lastColumnsLongestText = 0;
            int longestText = 0;
            int col = 0;
            for (int i = 0; i < _memoryChunks.Length; i++) {
                var currentColumn = _memoryChunks[i].Span;
                for (int j = 0; j < currentColumn.Length; j++) {
                    var instance = currentColumn[j];
                    spriteBatch.DrawString(_spriteFont, $"{instance.OverrideChar}",
                        new Vector2(col * Globals.TileSize + (lastColumnsLongestText * Globals.TileSize), j * Globals.TileSize), Color.Green);
                    spriteBatch.DrawString(_spriteFont, $"{instance.Text}",
                        new Vector2(col * Globals.TileSize + (lastColumnsLongestText * Globals.TileSize) + (instance.OverrideChar.Length + distanceBetween * Globals.TileSize), 
                        j * Globals.TileSize), Color.White);
                    int fullLength = instance.OverrideChar.Length + instance.OverrideChar.Length + instance.Text.Length + distanceBetween;
                    if (fullLength > longestText) {
                        longestText = fullLength;
                    }
                }
                col++;
                lastColumnsLongestText += longestText;
                longestText = 0;
            }
        }
    }
}
