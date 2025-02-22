using UnityEngine;

namespace DragRoot
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent (typeof(Movement))]
    public class Drag : MonoBehaviour
    {
        private Movement _movement;
        private Overlaper _overlap;
        private Vector3 _stPos;

        public bool IsDragging { get; private set; } = false;
        public bool IsSloted { get; private set; } = false;
        public bool IsActive { get; private set; } = true;
        public Slot Slot;

        private void Start()
        {
            _overlap = new Overlaper(transform);
            _movement = GetComponent<Movement>();
            _movement.targetPosition = transform.position;
            _stPos = transform.position;
        }

        private void Update()
        {
            if (IsActive == false)
                return;

            if (IsDragging == false)
                return;

            _movement.Move();
        }

        private void OnMouseDown()
        {
            if (IsSloted)
                return;

            if (IsActive == false)
                return;

            G.main.StartDrag();
            IsDragging = true;
            OnMouseDrag();
        }

        private void OnMouseDrag()
        {
            if (IsActive == false)
                return;

            Vector2 tr = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            _movement.targetPosition = tr;
        }

        private void OnMouseUp()
        {
            if (IsActive == false)
                return;

            IsDragging = false;

            Slot[] slots = _overlap.OverlapAll(0.5f);

            if (slots == null)
            {
                _movement.targetPosition = _stPos;
                return;
            }

            foreach (var slot in slots)
            {
                if (slot.Card)
                {
                    _movement.targetPosition = _stPos;
                    continue;
                }

                slot.Card = true;
                Slot = slot;
                IsSloted = true;
                _movement.targetPosition = slot.transform.position;
            }
        }
    }
}
