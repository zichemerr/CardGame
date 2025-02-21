using CMS.DragSystem;
using CMS.EntryPoint;
using UnityEngine;

namespace CMS.TurnSystem
{
    public class Board : CompositeRoot
    {
        public Slot[] PlayerSlots;
        public Slot[] EnemySlots;

        public override void Init()
        {
            for (int i = 0; i < PlayerSlots.Length; i++)
            {
                EnemySlots[i].EnemySlot = PlayerSlots[i];
                PlayerSlots[i].EnemySlot = EnemySlots[i];
            }
        }
    }
}
