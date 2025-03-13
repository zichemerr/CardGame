using MerJame.Audio;
using MerJame.Locator;
using MerJame.ParticleSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MerJame.Infrastructure
{
    public class Root : MonoBehaviour
    { 
        public static IServiceLocator<IService> Main { get; private set; }
        public static AudioSystem Audio {  get; private set; }
        public static ParticleRoot Effect => Main.Get<ParticleRoot>();
        public static AudioSounds Sound => Audio.Sound;

        private void Awake()
        {
            CompositeRoot[] roots = FindObjectsOfType<CompositeRoot>();
            Main = new ServiceLocator<IService>();
            Audio = new AudioSystem();
            
            foreach (var root in roots)
            {
                Main.Register<CompositeRoot>(root);
            }
            
            foreach (var root in roots)
            {
                root.Ready();
            }

            foreach (var root in roots)
            {
                root.Init();
            }
        }
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}