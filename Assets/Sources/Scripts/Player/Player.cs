using CMS.CardSystem;
using CMS.DragSystem;
using UnityEngine;
using MerJame.Infrastructure;
using CMS.HealthSystem;

namespace CMS.PlayerSystem
{    
    [RequireComponent(typeof(Health))]
    public class Player : CompositeRoot
    {
        [SerializeField] private Dragable[] _dragables;

        private CardAlign _cardAlign;
        private CardSpawnerController _cardSpawnerController;
        private Health _health;

        public bool IsDied { get; private set; } = false;
        
        public override void Ready()
        {
            _cardAlign = Root.Main.Get<CardAlign>();
            _cardSpawnerController = Root.Main.Get<CardSpawnerController>();
            _cardSpawnerController.Spawned += OnSpawned;
        }

        public override void Init()
        {
            _health = GetComponent<Health>();
            _health.Init();
            _health.Died += OnDied;
        }
        
        private void OnDied()
        {
            IsDied = true;
        }

        private void OnSpawned(Dragable dragable)
        {
            dragable.Init();
            _cardAlign.AddDragable(dragable);
        }

        private void Update()
        {
            _cardAlign?.Align();
        }
        
        public void TakeDamage(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}
