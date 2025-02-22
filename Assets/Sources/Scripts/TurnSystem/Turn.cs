using System.Collections;
using UnityEngine;
using CMS.DragSystem;
using CMS.EnemySystem;
using CMS.PlayerSystem;
using CMS.EntryPoint;
using CMS.Life;
using UnityEngine.UI;

namespace CMS.TurnSystem
{
    public class Turn : CompositeRoot
    {
        [SerializeField] private Button _button;

        private Board _board;
        private Player _player;
        private Enemy _enemy;

        public override void Init()
        {
            _board = Root.Main.Get<Board>();
            _player = Root.Main.Get<Player>();
            _enemy = Root.Main.Get<Enemy>();
        }

        [ContextMenu("fef")]
        public void OnTurn()
        {
            _button.interactable = false;
            StartCoroutine(TurnRoutine());
        }

        private IEnumerator TurnRoutine()
        {
            yield return Attacking(true);
            yield return new WaitForSeconds(1);
            yield return Attacking(false);
            _button.interactable = true;
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

                if (slot.OponentSlot.Card == null)
                {
                    if (isPlayer)
                        _enemy.TakeDamage(slot.Card.Attack);
                    else
                        _player.TakeDamage(slot.Card.Attack);

                    continue;
                }

                slot.OponentSlot.Card.TakeDamage(slot.Card.Attack);
            }
        }
    }
}
