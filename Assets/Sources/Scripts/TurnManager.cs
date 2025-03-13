using MerJame.Infrastructure;
using System.Collections;
using CMS.CardSystem;
using CMS.PlayerSystem;
using CMS.EnemySystem;
using CMS.EventSystem;
using UnityEngine;

namespace CMS.TurnSystem
{
    public class TurnManager : CompositeRoot
    {
        private Grid _grid;
        private TurnView _view;
        private Opponent _opponent;
        private GameEvents _gameEvents;
        private Player _player; 
        private bool _isActive = true;
        
        public override void Init()
        {
            _grid = Root.Main.Get<Grid>();
            _view = Root.Main.Get<TurnView>();
            _opponent = Root.Main.Get<Opponent>();
            _player = Root.Main.Get<Player>();
            _gameEvents = Root.Main.Get<GameEvents>();
            _gameEvents.Finished += OnFinished;
        }

        private void OnFinished()
        {
            _isActive = false;
            _view.DisableButton();
        }

        private IEnumerator TurnRoutine()
        {
            _view.DisableButton();
            yield return StartCoroutine(AttackTurn(true));
            yield return new WaitForSeconds(1);
            yield return StartCoroutine(AttackTurn(false));
            yield return new WaitForSeconds(0.5f);
            
            //Нужно проверять победу или пораджение в конце хода
            StartCoroutine(GameEventCheck());
        }

        private IEnumerator GameEventCheck()
        {
            if (_opponent.IsDied)
            {
                _gameEvents.Win();
                yield break;
            }

            if (_player.IsDied)
            {
                _gameEvents.Lose();
                yield break;
            }
            
            _view.EnableButton();
        }
        
        private IEnumerator AttackTurn(bool isPlayerTurn)
        {
            Slot[] slots = isPlayerTurn ? _grid.PlayerSlots : _grid.OpponentSlots;

            if (slots == null)
                yield break;
            
            foreach (var slot in slots)
            {
                if (slot.Card == null)
                    continue;

                yield return StartCoroutine(slot.Card.AttackAnimation());
                
                if (slot.OpponentSlot.Card == null)
                {
                    if (isPlayerTurn)
                    {
                        Root.Main.Get<Opponent>().TakeDamage(slot.Card.Damage);
                    }
                    else
                    {
                        Root.Main.Get<Player>().TakeDamage(slot.Card.Damage);
                    }
                    
                    continue;
                }
                
                slot.OpponentSlot.Card.TakeDamage(slot.Card.Damage);
            }
        }
        
        public void Turn()
        {
            if (_isActive == false)
                return;
            
            StartCoroutine(TurnRoutine());
        }
    }
}
