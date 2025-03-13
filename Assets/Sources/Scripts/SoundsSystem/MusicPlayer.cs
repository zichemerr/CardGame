using MerJame.Infrastructure;
using UnityEngine;

namespace MerJame.Music
{
    public class MusicPlayer : CompositeRoot
    {
        [SerializeField] private AudioClip _piano;

        public override void Init()
        {
            Play(Data.Audio.Musics.Ambnient, 0.2f);

            if (_piano == null)
            {
                Play(Root.Sound.PianoMusic);
                return;
            }

             Play(_piano);
        }

        private void Play(AudioClip clip, float volume = 1f)
        {
            AudioSource prefab = Data.Prefabs.AudioSourceContainer.AudioSource;
            AudioSource source = Instantiate(prefab);

            source.volume = volume;
            source.loop = true;
            source.clip = clip;
            source.Play();
        }
    }
}
