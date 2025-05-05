using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Movement settings
    [Header("Movement Settings")]
    [Tooltip("Character's movement speed (units/second)")]
    [Range(0f, 10f)]
    [SerializeField] private float speed;

    // Position Limits
    [Header("Position Limits")]
    [Tooltip("Minimum limit for the X axis")]
    public float minX;
    [Tooltip("Maximum limit for the X axis")]
    public float maxX;
    [Tooltip("Minimum limit for the Z axis")]
    public float minZ;
    [Tooltip("Maximum limit for the Z axis")]
    public float maxZ;

    // Smooth Rotation
    [Header("Smooth Rotation Settings")]
    private float currentZ = 0f;
    private float targetZ;
    private float preTargetZ = 0f;

    private float currentX = 0f;
    private float targetX = 0f;
    private float preTargetX = 0f;

    [Tooltip("Speed of the smooth rotation")]
    private float tx; // Lerp factor for X rotation
    private float tz; // Lerp factor for Z rotation

    // Player Movement variables
    [Header("Player Movement Variables")]
    private Rigidbody rb;

    private float horizontal;
    private float vertical;

    // Fire variables
    [Header("Fire Settings")]
    [Tooltip("Fire rate (shots per second)")]
    [SerializeField] private float fireRate;
    private float nextFire;

    // Bullet settings
    [Header("Bullet Settings")]
    [Tooltip("Bullet prefab")]
    [SerializeField] private GameObject bolt;
    [Tooltip("Bullet spawn position")]
    [SerializeField] private GameObject boltSpawn;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        vertical = 0f;
    }

    private void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        #region Smooth Rotation

        // Calculate targetX based on vertical input
        if (vertical > 0f) targetX = 10f;
        else if (vertical < 0f) targetX = -10f;
        else targetX = 0f;

        // Reset lerp timer if target changes
        if (preTargetX != targetX)
        {
            tx = 0f;
            preTargetX = targetX;
        }

        tx += Time.deltaTime * speed;
        tx = Mathf.Clamp01(tx);

        // Smoothly interpolate to target rotation on X axis
        currentX = Mathf.Lerp(currentX, targetX, tx);
        if (Mathf.Abs(currentX) < 0.01f) currentX = 0f;

        // Calculate targetZ based on horizontal input
        if (horizontal > 0f) targetZ = -20f;
        else if (horizontal < 0f) targetZ = 20f;
        else targetZ = 0f;

        // Reset lerp timer if target changes
        if (preTargetZ != targetZ)
        {
            tz = 0f;
            preTargetZ = targetZ;
        }

        tz += Time.deltaTime * speed;
        tz = Mathf.Clamp01(tz);

        // Smoothly interpolate to target rotation on Z axis
        currentZ = Mathf.Lerp(currentZ, targetZ, tz);
        if (Mathf.Abs(currentZ) < 0.01f) currentZ = 0f;

        #endregion

        #region Bolt Spawn

        // Fire bullet if allowed and game is not paused
        if (Input.GetButton("Fire1") && Time.time > nextFire && Time.timeScale != 0)
        {
            nextFire = Time.time + fireRate;
            Instantiate(bolt, boltSpawn.transform.position, boltSpawn.transform.rotation);
        }

        #endregion
    }

    private void FixedUpdate()
    {
        // Apply movement based on input
        Vector3 Movement = new Vector3(horizontal * speed, 0f, vertical * speed);
        rb.linearVelocity = Movement;

        // Clamp player position within limits
        Vector3 clampedPosition = new Vector3(
            Mathf.Clamp(rb.transform.position.x, minX, maxX),
            0f,
            Mathf.Clamp(rb.transform.position.z, minZ, maxZ)
        );

        rb.position = clampedPosition;

        // Apply rotation based on calculated smooth angles
        rb.rotation = Quaternion.Euler(currentX, 0f, currentZ);
    }
}
