using UnityEngine;

public class AsteroidPysics : MonoBehaviour
{
    float speed;
    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = Random.Range(2f, 4f);

        rb.angularVelocity = Random.insideUnitSphere;
    }

    void FixedUpdate()
    {
        if (rb != null)
        {
            Vector3 Movement = new Vector3(0f, 0f, -speed);
            rb.linearVelocity = Movement;
        }
    }
}
