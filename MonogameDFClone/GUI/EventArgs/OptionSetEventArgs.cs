namespace MonogameDFClone.GUI {
    public class OptionSetEventArgs : EventArgs {
        public int Index;
        public string Text;
        public OptionSetEventArgs(int index, string text) {
            Index = index;
            Text = text;
        }

    }
}
