using UnityEngine;
using CMS.PlayerSystem;
using CMS.EntryPoint;
using CMS.EnemySystem;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

namespace CMS.Event
{
    public class GameEvent : CompositeRoot
    {
        [SerializeField] private FinishAnimation _finishAnimation;

        private Player _player;
        private Enemy _enemy;

        public override void Init()
        {
            _player = Root.Main.Get<Player>();
            _enemy = Root.Main.Get<Enemy>();

            _player.Died += OnPlayerDied;
            _enemy.Died += OnEnemyDied;
        }

        private void OnPlayerDied()
        {
            StartCoroutine(LoseRoutine());
        }

        private void OnEnemyDied()
        {
            StartCoroutine(WinRoutine());
        }

        private IEnumerator WinRoutine()
        {
            yield return _finishAnimation.Play("Victory", Color.green, Color.white);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        private IEnumerator LoseRoutine()
        {
            yield return _finishAnimation.Play("Defeat", Color.black, Color.red);
            yield return new WaitForSeconds(1f);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
