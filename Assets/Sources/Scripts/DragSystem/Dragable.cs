using CMS.CardSystem;
using System.Net.NetworkInformation;
using UnityEngine;

namespace CMS.DragSystem
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Dragable : MonoBehaviour
    {
        public float _time = 0.1f;
        public float _radius;

        private Vector2 _startPos;

        [HideInInspector] public bool Dragging = false;
        [HideInInspector] public Card Card;
        [HideInInspector] public bool IsSloted = false;

        private void Start()
        {
            Card = GetComponent<Card>();
            _startPos = transform.position;
        }

        private void OnMouseDown()
        {
            Dragging = true;
        }

        private void Update()
        {
            if (Dragging)
                return;

            if (Vector2.Distance(transform.position, _startPos) < 0.01f)
            {
                if (IsSloted)
                {
                    Destroy(this);
                }
            }

            transform.position = Vector2.Lerp(transform.position, _startPos, _time);
        }

        private void OnMouseDrag()
        {
            if (Dragging == false)
                return;

            Vector2 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = Vector2.Lerp(transform.position, target, _time);
        }

        private void OnMouseUp()
        {
            Dragging = false;

            Collider2D[] colls = Physics2D.OverlapCircleAll(transform.position, _radius);

            foreach (var coll in colls)
            {
                if (coll.TryGetComponent(out Slot slot))
                {
                    _startPos = slot.transform.position;

                    Card.slot = slot;
                    slot.Card = Card;
                    IsSloted = true;
                }
            }
        }
    }
}
