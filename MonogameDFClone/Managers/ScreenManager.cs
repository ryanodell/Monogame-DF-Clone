using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonogameDFClone.Screens;

namespace MonogameDFClone.Managers {
    public class ScreenManager {
        private static ScreenManager instance;

        public ScreenBase CurrentScreen { private set; get; }

        public static ScreenManager Instance {
            get {
                if (instance == null) {
                    instance = new ScreenManager();                    
                }
                return instance;
            }
        }

        public void ChangeScreen(ScreenBase screen) {
            CurrentScreen?.UnloadContent();
            CurrentScreen = screen;
            CurrentScreen.LoadContent();
        }

        public void LoadContent() {
            CurrentScreen?.LoadContent();
        }

        public void Update(GameTime gameTime) {
            CurrentScreen?.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime) {
            CurrentScreen?.Draw(spriteBatch, gameTime);
        }
    }
}
