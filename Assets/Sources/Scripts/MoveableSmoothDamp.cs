using MerJame.Infrastructure;
using UnityEngine;
using UnityEngine.Serialization;

public class MoveableSmoothDamp : MonoBehaviour
{
    [FormerlySerializedAs("targetPosition")] public Vector2 TargetPosition;
    private Vector2 velocity;
    public float smoothTime = 0.2f;
    public float maxVelocity = 60f;
    private Vector2 currentVelocity;

    private void Update()
    {
        MoveXY();
    }

    protected void MoveXY()
    {
        if (Vector2.Distance(transform.position, TargetPosition) > 0.01f || velocity.magnitude > 0.01f)
        {
            Vector2 newPosition = Vector2.SmoothDamp(transform.position, TargetPosition, ref currentVelocity, smoothTime, maxVelocity, Time.deltaTime);
            velocity = (newPosition - (Vector2)transform.position) / Time.deltaTime;

            if (velocity.sqrMagnitude > maxVelocity * maxVelocity)
            {
                velocity = velocity.normalized * maxVelocity;
            }

            transform.position = newPosition + velocity * Time.deltaTime;
            if (Vector2.Distance((Vector2)transform.position, TargetPosition) < 0.01f && velocity.magnitude < 0.01f)
            {
                transform.position = new Vector3(TargetPosition.x, TargetPosition.y, transform.position.z);
                velocity = Vector2.zero;
            }
        }
    }
}