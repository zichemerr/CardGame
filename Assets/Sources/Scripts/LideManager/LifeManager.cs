using UnityEngine;
using System.Collections;
using CMS.EntryPoint;

namespace CMS.Life
{
    public class LifeManager : CompositeRoot
    {
        public int PlayerDamage { get; private set; }
        public int OpponentDamage { get; private set; }

        public int Balance { get { return OpponentDamage - PlayerDamage; } }

        public override void Init()
        {
            Reset();
        }

        public void Reset()
        {
            OpponentDamage = 0;
            PlayerDamage = 0;
        }

        public IEnumerator Damage(int damage, bool toPlayer)
        {
            if (toPlayer)
            {
                PlayerDamage += damage;
            }
            else
            {
                OpponentDamage += damage;
            }

            yield return new WaitForSeconds(0.2f);
        }
    }
}