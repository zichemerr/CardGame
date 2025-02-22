using UnityEngine;

namespace DragRoot
{
    public class Movement : MonoBehaviour
    {
        public Vector2 targetPosition;
        public float smoothTime = 0.3F;
        public float maxVelocity = 10f;

        private Vector2 velocity;
        private Vector2 currentVelocity;

        public void Move()
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
