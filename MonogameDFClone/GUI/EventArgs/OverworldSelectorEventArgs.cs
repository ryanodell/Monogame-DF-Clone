namespace MonogameDFClone.GUI {
    public class OverworldSelectorEventArgs : EventArgs {
        public int Column;
        public int Row;

        public OverworldSelectorEventArgs(int column, int row) {
            Column = column;
            Row = row;
        }
    }
}
