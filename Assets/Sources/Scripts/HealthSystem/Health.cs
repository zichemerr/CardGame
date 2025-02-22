using CMS.EntryPoint;
using System;
using UnityEngine;

namespace CMS.HealthSystem
{
    public abstract class Health : CompositeRoot
    {
        [SerializeField] private int _startHealth;

        public event Action Died;
        public int Value { get; private set; }

        public override void Init()
        {
            Value = _startHealth;
        }

        public void TakeDamage(int damage)
        {
            Value -= damage;

            if (Value <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}
