using UnityEngine;

public class ConfettiFloatBehavior : MonoBehaviour
{
    public float fallSpeed = 0.2f;             // Slow downward movement
    public float driftStrength = 0.5f;         // Horizontal wind drifting
    public float rotationSpeed = 30f;          // Rotation for fluttering
    private float lifeTime = 1000f;

    private Vector3 driftDirection;

    void Start()
    {
        // Random wind direction
        driftDirection = new Vector3(
            Random.Range(-1f, 1f),
            0f,
            Random.Range(-1f, 1f)
        ).normalized;

        // Destroy after a while
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        // Downward movement
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Sideways drifting like wind
        transform.position += driftDirection * driftStrength * Mathf.Sin(Time.time * 2f) * Time.deltaTime;

        // Gentle fluttering rotation
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
        transform.Rotate(Vector3.right, rotationSpeed * 0.5f * Mathf.Sin(Time.time * 3f) * Time.deltaTime);
    }
}
