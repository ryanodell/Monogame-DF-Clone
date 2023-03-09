using MonogameDFClone.Models;

namespace MonogameDFClone.GUI {
    public class KeyboardMenuEventArgs : EventArgs {
        public KeyboardMenuItem SelectedMenu;

        public KeyboardMenuEventArgs(KeyboardMenuItem selectedMenu) {
            SelectedMenu = selectedMenu;
        }
    }
}
