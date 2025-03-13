using UnityEngine;

namespace MerJame.Audio
{
    public class AudioSystem
    {
        private AudioSource _audioSource;

        public AudioSounds Sound {  get; private set; }

        public AudioSystem()
        {
            AudioSource prefab = Data.Prefabs.AudioSourceContainer.AudioSource;
            Sound = Data.Prefabs.Sounds.AudioSounds;

            _audioSource = GameObject.Instantiate(prefab);
        }

        public void Play(AudioClip clip, float volume = 1, bool loop = false)
        {
            _audioSource.loop = loop;
            _audioSource.volume = volume;
            _audioSource.PlayOneShot(clip);
        }

        public void Stop()
        {
            _audioSource.Stop();
        }
    }
}