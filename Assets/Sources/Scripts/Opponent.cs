using UnityEngine;
using CMS.CardSystem;
using CMS.HealthSystem;
using MerJame.Infrastructure;

namespace CMS.EnemySystem
{
    [RequireComponent(typeof(Health))]
    public class Opponent : CompositeRoot
    {
        [SerializeField] private EnemyCard[] _cards;
        
        private Health _health; 
        
        public bool IsDied { get; private set; } = false;
        
        public override void Init()
        {
            _health = GetComponent<Health>();
            _health.Died += OnDied;
            _health.Init();
            
            foreach (var card in _cards)
            {
                card.Init();
            }
        }

        private void OnDied()
        {
            IsDied = true;
        }

        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}