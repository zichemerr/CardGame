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
                EnemySlots[i].SetOponentSlot(PlayerSlots[i]);
                PlayerSlots[i].SetOponentSlot(EnemySlots[i]);
            }
        }
    }
}
