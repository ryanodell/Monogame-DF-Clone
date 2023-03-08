using Microsoft.Xna.Framework.Media;

namespace MonogameDFClone.Managers {
    public class AudioManager {
        public static bool Mute;
        private static AudioManager _instance;
        public Song CurrentSong { private set; get; }

        public static AudioManager Instance {
            get {
                if(_instance == null) {
                    return new AudioManager();
                }
                return _instance;
            }
        }

        public void PlaySong(string songName) {
            if (Mute) {
                return;
            }
            CurrentSong = AssetManager.Instance.GetSong(songName);
            MediaPlayer.Play(CurrentSong);
        }

        public void PlaySong(Song song) {
            if(Mute) {
                return;
            }
            CurrentSong = song;
            MediaPlayer.Play(song);
        }

        public void Stop() {
            MediaPlayer.Stop();
        }

        public void SetVolume(float volume) {
            MediaPlayer.Volume = volume;
        }
    }
}
