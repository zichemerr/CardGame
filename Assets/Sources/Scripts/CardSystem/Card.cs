using System.Collections;
using UnityEngine;
using CMS.EntryPoint;
using CMS.DragSystem;

namespace CMS.CardSystem
{
    public class Card : CompositeRoot
    {
        public Slot slot;
        public int health;
        public int attack;

        private float _time = 0.1f;

        private void Update()
        {
            if (slot == null)
                return;

            transform.position = Vector2.Lerp(transform.position, slot.transform.position, _time);
        }

        public void TakeDamage(int damage)
        {
            health -= damage;

            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }

        public void AttackAnimation()
        {
            StartCoroutine(Anima());
        }

        private IEnumerator Anima()
        {
            transform.position += transform.up * 0.5f;
            yield return new WaitForSeconds(0.6f);
        }
    }
}