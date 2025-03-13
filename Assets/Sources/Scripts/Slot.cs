using UnityEngine;

namespace CMS.CardSystem
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Slot : MonoBehaviour
    {
        public Slot OpponentSlot;
        public Card Card;
    }
}