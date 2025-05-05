using UnityEngine;

public class PlayerBoltController : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private float boltSpeed;
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        rb.linearVelocity = new Vector3(0f, 0f, boltSpeed);
    }

    private void FixedUpdate()
    {
        if (rb == null) return;

        if (rb.position.z > 7.5f) Destroy(gameObject);
    }
}
