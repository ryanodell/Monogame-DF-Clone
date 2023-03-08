using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace MonogameDFClone.Managers {
    public class InputManager {
        public static InputManager? _instance;
        private static KeyboardState _previousKeyState;
        private static KeyboardState _currentKeyState;

        public static InputManager Instance {
            get {
                if(_instance == null) {
                    _instance = new InputManager();
                }
                return _instance;
            }
        }

        public void Update(GameTime gameTime) {
            _previousKeyState = _currentKeyState;
            _currentKeyState = Keyboard.GetState();
        }

        public bool IsInputAction(eInputAction action) {
            if (action == eInputAction.Right) {
                return _keyPressed(Keys.Right);
            }
            if (action == eInputAction.Left) {
                return _keyPressed(Keys.Left);
            }
            if (action == eInputAction.Up) {
                return _keyPressed(Keys.Up);
            }
            if (action == eInputAction.Down) {
                return _keyPressed(Keys.Down);
            }
            if (action == eInputAction.Select) {
                return _keyPressed(Keys.Space);
            }
            if (action == eInputAction.Combat) {
                return _keyPressed(Keys.OemTilde);
            }
            return false;
        }
        private static bool _keyPressed(Keys key) {
            return _currentKeyState.IsKeyDown(key) && !_previousKeyState.IsKeyDown(key);
        }
    }
}
