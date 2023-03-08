using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;

namespace MonogameDFClone.GUI {
    internal class OptionSet : GuiItem {
        public EventHandler<OptionSetEventArgs> On_IndexChanged;
        public EventHandler<OptionSetEventArgs> On_ItemSelected;
        private string[] _options;
        private int _currentIndex = 0;
        public Vector2 Position;
        private SpriteFont _spriteFont = Globals.GameReference.Content.Load<SpriteFont>("Resources/SDS_8x8");
        public OptionSet(bool visible, bool active) : base(visible, active) { }

        public OptionSet(bool visible, bool active, string[] options) : base(visible, active) {
            _options = options;
        }
        public OptionSet(bool visible, bool active, List<string> options) : base(visible, active) {
            _options = options.ToArray();
        }

        public void IncrementIndex() {
            _currentIndex++;
        }

        public void DecrementIndex() {
            _currentIndex--;
        }

        public bool AddOption(string option, int? index = null) {
            if (index != null) {
                _options.Append(option);
                return true;
            }
            else {
                return false;
            }
        }

        public override void Update(GameTime gameTime) {
            if (!Active) return;

            int originalIndex = _currentIndex;
            if (InputManager.Instance.IsInputAction(eInputAction.Down)) {
                if(_currentIndex + 1 >= _options.Length) {
                    return;
                }
                _currentIndex++;
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Up)) {
                if(_currentIndex - 1 < 0) {
                    return;
                }
                _currentIndex--;
            }
            if(originalIndex != _currentIndex) {
                On_IndexChanged?.Invoke(this, new OptionSetEventArgs(_currentIndex, _options[_currentIndex]));
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Select)) {
                On_ItemSelected?.Invoke(this, new OptionSetEventArgs(_currentIndex, _options[_currentIndex]));
            }
        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            if (!Visible) return;
            for(int i = 0; i < _options.Length; i++) {
                spriteBatch.DrawString(_spriteFont, _options[i], Position + new Vector2(0, i * Globals.TileSize),
                    _currentIndex == i ? Color.White : Color.Gray);
            }
        }
    }
}
