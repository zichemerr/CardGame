using UnityEngine;
using System;
using System.Collections;

namespace CMS.CardSystem
{
    public class Card : MonoBehaviour
    {
        public int Health { get; private set; } = 5;
        public int Damage { get; private set; } = 2;
        public event Action<Vector2> Sloted;
        
        private void OnMouseUp()
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 0.2f);

            foreach (var collider in colliders)
            {
                if (collider.TryGetComponent(out Slot slot))
                {
                    if (slot.Card != null)
                        continue;
                    
                    slot.Card = this;
                    Sloted?.Invoke(slot.transform.position);
                }
            }
        }

        public IEnumerator AttackAnimation()
        {
            transform.localPosition += transform.up * 0.5f;
            yield return new WaitForSeconds(0.5f);
        }
        
        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}