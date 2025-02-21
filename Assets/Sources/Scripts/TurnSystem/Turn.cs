using CMS.DragSystem;
using CMS.EntryPoint;
using CMS.Life;
using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

namespace CMS.TurnSystem
{
    public class Turn : CompositeRoot
    {
        private Board _board;
        private LifeManager _lifeManager;

        public override void Init()
        {
            _board = Root.Main.Get<Board>();
            _lifeManager = Root.Main.Get<LifeManager>();
        }

        [ContextMenu("fef")]
        public void OnTurn()
        {
            StartCoroutine(TurnRoutine());
        }

        private IEnumerator TurnRoutine()
        {
            yield return Attacking(true);
            yield return new WaitForSeconds(1);
            yield return Attacking(false);

            if (PlayerIsWinner())
            {
                Debug.Log("PlayerWin");
            }

            if (GameHasEnded())
            {
                Debug.Log("GameHasEnded");
            }
        }

        private IEnumerator Attacking(bool isPlayer)
        {
            var slots = isPlayer ? _board.PlayerSlots : _board.EnemySlots;

            foreach (var slot in slots)
            {
                if (slot.Card == null)
                    continue;

                slot.Card.AttackAnimation();
                yield return new WaitForSeconds(0.1f);

                if (slot.EnemySlot.Card == null)
                {
                    yield return _lifeManager.Damage(slot.Card.attack, !isPlayer);
                    Debug.Log(_lifeManager.Balance);
                    continue;
                }

                slot.EnemySlot.Card.TakeDamage(slot.Card.attack);
            }
        }

        private bool PlayerIsWinner()
        {
            return _lifeManager.Balance >= 5;
        }

        private bool GameHasEnded()
        {
            return _lifeManager.Balance < 0;
        }
    }
}
