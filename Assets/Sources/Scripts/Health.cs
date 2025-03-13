using System;
using UnityEngine;

namespace CMS.HealthSystem
{
    [RequireComponent(typeof(HealthView))]
    public class Health : MonoBehaviour
    {        
        private HealthView _healthView;
        private int _health = 5;

        public event Action Died;
        
        public void Init()
        {
            _healthView = GetComponent<HealthView>();
            _healthView.SetMaxValue(_health);
            _healthView.SetValue(_health);
        }
        
        public void TakeDamage(int damage)
        {
            _health -= damage;
            _healthView.SetValue(_health);

            if (_health <= 0)
            {
                Died?.Invoke();
            }
        }
    }
}