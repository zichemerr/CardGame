using CMS.CardSystem;
using MerJame.Infrastructure;
using UnityEngine;

namespace CMS
{
    public class Grid : CompositeRoot
    {
        [field: SerializeField] public Slot[] PlayerSlots { get; private set; }
        [field: SerializeField] public Slot[] OpponentSlots { get; private set; }
        
        public override void Init()
        {
            for (int i = 0; i < PlayerSlots.Length; i++)
            {
                PlayerSlots[i].OpponentSlot  = OpponentSlots[i];
                OpponentSlots[i].OpponentSlot = PlayerSlots[i];
            }
        }
    }
}
