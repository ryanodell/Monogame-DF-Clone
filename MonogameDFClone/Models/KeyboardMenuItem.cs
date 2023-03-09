using Microsoft.Xna.Framework.Input;


namespace MonogameDFClone.Models {
    public class KeyboardMenuItem {
        public Keys Key;
        public string Text;
        public string OverrideChar;

        public KeyboardMenuItem(Keys key, string text) {
            Key = key;
            Text = text;
            OverrideChar = key.ToString();
        }

        public KeyboardMenuItem(Keys key, string text, string overrideChar) {
            Key = key;
            Text = text;
            OverrideChar = overrideChar;
        }
    }
}
