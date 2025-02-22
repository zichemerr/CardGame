using System.Collections;
using UnityEngine;
using CMS.EntryPoint;
using CMS.DragSystem;

namespace CMS.CardSystem
{
    public class Card : CompositeRoot
    {
        public Slot Slot;
        public int Health;
        public int Attack;

        private float _time = 0.1f;

        private void Update()
        {
            if (Slot == null)
                return;

            transform.position = Vector2.Lerp(transform.position, Slot.transform.position, _time);
        }

        private IEnumerator Anima()
        {
            transform.position += transform.up * 0.5f;
            yield return new WaitForSeconds(0.6f);
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;

            if (Health <= 0)
            {
                Slot.SetCard(null);
                Destroy(gameObject);
            }
        }

        public void AttackAnimation()
        {
            StartCoroutine(Anima());
        }

        public void SetSlot(Slot slot)
        {
            this.Slot = slot;
        }
    }
}