using System.Collections.Generic;

namespace MonogameDFClone.Shared {
    public class SpriteSheetTile {
        public int Column { get; set; }
        public int Row { get; set; }
        public string Name { get; set; }
        public List<string> MetaData { get; set; }
        public SpriteSheetTile(int column, int row) {
            Column = column;
            Row = row;
        }
        public SpriteSheetTile(int column, int row, List<string> metaData) {
            Column = column;
            Row = row;
            MetaData = metaData;
        }

    }
}
