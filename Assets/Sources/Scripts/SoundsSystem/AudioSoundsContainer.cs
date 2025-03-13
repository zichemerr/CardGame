using MerJame;
using UnityEngine;

namespace CMS
{
    public class AudioSoundsContainer : MonoBehaviour
    {
        [SerializeField] private AudioSounds _sounds;

        public AudioSounds AudioSounds => _sounds;
    }
}
