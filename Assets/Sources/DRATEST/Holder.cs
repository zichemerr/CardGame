using UnityEngine;

namespace DragRoot
{
    public class Holder : MonoBehaviour
    {
        public Drag _drag;
        public Movement moveme;
        public bool пришли = false;

        private void Update()
        {
            if (_drag.IsSloted == false)
                return;

            if (Vector2.Distance(transform.position, _drag.Slot.transform.position) < 0.01f)
            {
                пришли = true;
            }

            if (пришли)
                return;

            moveme.targetPosition = _drag.Slot.transform.position;
            moveme.Move();
        }
    }
}
