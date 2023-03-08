using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.GUI;
using MonogameDFClone.Managers;

namespace MonogameDFClone.Screens {
    public class MainMenu : ScreenBase {
        private OptionSet _optionSet;
        public override void LoadContent() {
            _optionSet = new OptionSet(true, true, new List<string>() { "Play", "Pathfinding", "Exit" });
            _optionSet.Position = new Vector2((Globals.GameReference.Graphics.PreferredBackBufferWidth / 2) - 6 * Globals.TileSize,
                Globals.GameReference.Graphics.PreferredBackBufferHeight / 2 - 5 * Globals.TileSize);
            _optionSet.On_IndexChanged += IndexChanged;
            _optionSet.On_ItemSelected += ItemSelected;
        }

        public void IndexChanged(object sender, OptionSetEventArgs args) {
            Console.WriteLine($"IndexChanged: {args.Index}, Text:{args.Text}");
        }

        public void ItemSelected(object sender, OptionSetEventArgs args) {
            if(args.Text == "Play") {
                ScreenManager.Instance.ChangeScreen(new OverworldScreen());
            }
            if (args.Text == "Pathfinding") {
                ScreenManager.Instance.ChangeScreen(new PathFindingScreen());
            }
            if (args.Text == "Exit") {
                Globals.GameReference.Exit();
            }
        }

        public override void UnloadContent() {

        }

        public override void Update(GameTime gameTime) {
            InputManager.Instance.Update(gameTime);
            _optionSet.Update(gameTime);

        }
        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            Globals.GameReference?.GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            _optionSet.Draw(spriteBatch, gameTime);
            spriteBatch.End();
        }
    }
}
