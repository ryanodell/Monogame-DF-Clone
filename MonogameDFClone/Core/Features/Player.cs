using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Core.Features {
    public class Player {
        public Player(Vector2 position) {
            Position = position;
        }
        public Vector2 Position;
        public Color Color = Color.White;
        public bool InCombatMode = false;

        public int Column {
            get {
                return (int)(Math.Ceiling((decimal)(Position.X / Globals.TileSize)));
            }
        }
        public int Row {
            get {
                return (int)(Math.Ceiling((decimal)(Position.Y / Globals.TileSize)));
            }
        }

        public string Idx {
            get {
                return $"{Column}_{Row}";
            }
        }


        public void Update(GameTime gameTime) {
            if (InputManager.Instance.IsInputAction(eInputAction.Right)) {
                if (Globals.Map.IsCellWalkable(Column + 1, Row)) {
                    Position = new Vector2(Position.X + Globals.TileSize, Position.Y);
                }
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Left)) {
                if (Globals.Map.IsCellWalkable(Column - 1, Row)) {
                    Position = new Vector2(Position.X - Globals.TileSize, Position.Y);
                }
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Down)) {
                if (Globals.Map.IsCellWalkable(Column, Row + 1)) {
                    Position = new Vector2(Position.X, Position.Y + Globals.TileSize);
                }
            }
            if (InputManager.Instance.IsInputAction(eInputAction.Up)) {
                if (Globals.Map.IsCellWalkable(Column, Row - 1)) {
                    Position = new Vector2(Position.X, Position.Y - Globals.TileSize);
                }
            }
            if(InputManager.Instance.IsInputAction(eInputAction.Combat)) {
                InCombatMode = !InCombatMode;
                AudioManager.Instance.PlaySong(InCombatMode ? Globals.CombatSongName 
                    : Globals.OverWorldSongName);
            }
        }

        public void Draw(SpriteBatch spriteBatch) {
            spriteBatch.Draw(AssetManager.Instance.Texture, Position, Globals.Rects.Dwarf1, Color);
        }
    }
}
