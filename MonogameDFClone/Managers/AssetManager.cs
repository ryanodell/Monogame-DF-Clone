using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Media;

namespace MonogameDFClone.Managers {
    public class AssetManager {
        public Texture2D Texture;
        private static AssetManager _instance;
        private static IDictionary<string, Song> _songs = new Dictionary<string, Song>();
        public static AssetManager Instance {
            get {
                if(_instance == null) {
                    _instance = new AssetManager();
                }
                return _instance;
            }
        }

        public Song GetSong(string songName) {
            return _songs[songName];
        }

        public void Init() {
            Texture = Globals.GameReference.Content.Load<Texture2D>("Resources/kruggsmash");
            _songs.Add(Globals.OverWorldSongName, _loadSong(Globals.OverWorldSongName));
            _songs.Add(Globals.CombatSongName, _loadSong(Globals.CombatSongName));
        }

        private Song _loadSong(string songName) {
            var fileLocation = new Uri($"{Environment.CurrentDirectory}\\Resources\\{songName}.ogg");
            return Song.FromUri(songName, fileLocation);
        }
    }
}
