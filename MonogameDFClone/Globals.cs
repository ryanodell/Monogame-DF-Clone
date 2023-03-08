using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Core.Tiling;

namespace MonogameDFClone {
    public static class Globals {
        public static int TileSize = 16;
        public static MainGame? GameReference;
        public static GameMap Map;
        public const string OverWorldSongName = "Overworld";
        public const string CombatSongName = "Combat";

        public static class Rects {
            public static readonly Rectangle Dwarf1 = new Rectangle(1 * TileSize, 0 * TileSize, TileSize, TileSize);
            public static readonly Rectangle Dwarf2 = new Rectangle(2 * TileSize, 0 * TileSize, TileSize, TileSize);
            public static readonly Rectangle Heart = new Rectangle(3 * TileSize, 0 * TileSize, TileSize, TileSize);
            public static readonly Rectangle Tree = new Rectangle(5 * TileSize, 0 * TileSize, TileSize, TileSize);
            public static readonly Rectangle Grass = new Rectangle(0 * TileSize, 6 * TileSize, TileSize, TileSize);
            public static readonly Rectangle AtSymbol = new Rectangle(0 * TileSize, 4 * TileSize, TileSize, TileSize);
            public static readonly Rectangle LargeX = new Rectangle(8 * TileSize, 5 * TileSize, TileSize, TileSize);
        }
    }
}
