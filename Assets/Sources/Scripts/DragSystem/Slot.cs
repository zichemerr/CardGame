using UnityEngine;
using CMS.CardSystem;
using System;

namespace CMS.DragSystem
{
    public class Slot : MonoBehaviour
    {
        public Card Card;
        public Slot OponentSlot { get; private set; }

        public void SetCard(Card card)
        {
            Card = card;
        }

        public void SetOponentSlot(Slot slot)
        {
            OponentSlot = slot;
        }
    }
}
