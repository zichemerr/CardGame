using CMS.CardSystem;
using UnityEngine;

namespace CMS.DragSystem
{
    [RequireComponent(typeof(BoxCollider2D))]
    public class Dragable : MonoBehaviour
    {
        public float _time = 0.1f;
        public float _radius;
        public float smoothTime = 0.3F;
        public float maxVelocity = 10f;
        public Vector2 targetPosition;

        private Vector2 _startPos;
        private Overlaper _over;
        private Vector2 velocity;
        private Vector2 currentVelocity;

        public Card Card { get; private set; }
        public bool Dragging { get; private set; } = false;
        public bool Sloted { get; private set; } = false;

        private void Awake()
        {
            Card = GetComponent<Card>();
            _over = new Overlaper(transform);
            _startPos = transform.position;
        }

        private void Update()
        {
            if (Dragging)
                return;

            if (Vector2.Distance(transform.position, _startPos) < 0.01f)
            {
                if (Sloted)
                {
                    Destroy(this);
                }
            }
        }

        private void OnMouseDown()
        {
            Dragging = true;
        }

        private void OnMouseDrag()
        {
            if (Dragging == false)
                return;

            targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            MoveXY();
        }

        private void OnMouseUp()
        {
            Slot[] slots = _over.OverlapAll(_radius);
            Dragging = false;

            if (slots == null)
                return;

            foreach (var slot in slots)
            {
                if (slot.Card != null)
                    continue;

                _startPos = slot.transform.position;

                slot.SetCard(Card);
                Card.SetSlot(slot);
                Sloted = true;
            }
        }

        protected void MoveXY()
        {
            if (Vector2.Distance(transform.position, targetPosition) > 0.01f || velocity.magnitude > 0.01f)
            {
                Vector2 newPosition = Vector2.SmoothDamp(transform.position, targetPosition, ref currentVelocity, smoothTime, maxVelocity, Time.deltaTime);
                velocity = (newPosition - (Vector2)transform.position) / Time.deltaTime;

                if (velocity.sqrMagnitude > maxVelocity * maxVelocity)
                {
                    velocity = velocity.normalized * maxVelocity;
                }

                transform.position = newPosition + velocity * Time.deltaTime;
                if (Vector2.Distance((Vector2)transform.position, targetPosition) < 0.01f && velocity.magnitude < 0.01f)
                {
                    transform.position = new Vector3(targetPosition.x, targetPosition.y, transform.position.z);
                    velocity = Vector2.zero;
                }
            }
        }
    }
}
