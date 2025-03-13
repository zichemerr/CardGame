using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using MerJame.Infrastructure;

namespace CMS.EventSystem
{
    public class GameEvents : CompositeRoot
    {
        [SerializeField] private FinishAnimation _animation;
        [SerializeField] private float _delay;
        
        public event Action Finished;
        
        public void Lose()
        {
            Finished?.Invoke();
            StartCoroutine(LoseRoutine());
        }

        public void Win()
        {
            Finished?.Invoke();
            StartCoroutine(WinRoutine());
        }

        private IEnumerator WinRoutine()
        {
            Root.Audio.Play(Data.Audio.Win);
            _animation.Play("Thanks for playing.", Color.black, Color.white);
            yield break;
        }

        private IEnumerator LoseRoutine()
        {
            yield return new WaitForSeconds(_delay);
            Root.Audio.Play(Data.Audio.Tddd);
            yield return _animation.Play("Defeat", Color.black, Color.red);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}