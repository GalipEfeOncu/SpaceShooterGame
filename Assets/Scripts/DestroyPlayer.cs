using System.Collections;
using UnityEngine;

[System.Serializable]

public class DestroyPlayer : MonoBehaviour
{
    [Header("Camera Shake Settings")]
    [SerializeField] private float shakeDuration; // Duration of the camera shake effect
    [SerializeField] private float shakeMagnitude; // Intensity of the shake
    [SerializeField] private Camera mainCamera;

    [Header("Player References")]
    [SerializeField] private GameObject playerExplosion;
    [SerializeField] private DeathScreen deathScreen;
    [SerializeField] private GameObject playerShip;
    [SerializeField] private IsTrigger isTrigger;
    [SerializeField] private IsTrigger isTrigger2;

    [SerializeField] private GameObject asteroidExplosion;

    private int playerHeal = 3; // Player's total health

    public int GetterPlayerHeal()
    {
        return playerHeal;
    }

    private void Update()
    {
        // Check both triggers for collision events
        if (isTrigger.isTrigger)
        {
            StartCoroutine(Wait(isTrigger.otherGameObject));
            isTrigger.isTrigger = false;
        }
        else if (isTrigger2.isTrigger)
        {
            StartCoroutine(Wait(isTrigger2.otherGameObject));
            isTrigger2.isTrigger = false;
        }
    }

    public IEnumerator Wait(Collider other)
    {
        playerHeal--; // Decrease player health
        StartCoroutine(ShakeCamera()); // Start shake effect
        if (playerHeal == 0)
        {
            // Player dies: play explosion, show death screen, stop game
            Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
            deathScreen.DeathScreenViewer();
            Destroy(playerShip.gameObject);
            yield return new WaitForSecondsRealtime(0.4f);
            Time.timeScale = 0f;
        }
        else
        {
            // Only destroy asteroid if player still has lives
            Instantiate(asteroidExplosion, other.transform.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
        Debug.Log("playerHeal: " + playerHeal);
    }

    public IEnumerator ShakeCamera()
    {
        Vector3 ogPosition = mainCamera.transform.position;
        float elapsed = 0f;

        float randomStart = Random.Range(0f, 100f); // Start shake randomness from random point

        while (elapsed < shakeDuration)
        {
            // Perlin Noise-based shake on X and Z axes
            float x = (Mathf.PerlinNoise(randomStart + elapsed * 10f, 0f) - 0.5f) * shakeMagnitude;
            float z = (Mathf.PerlinNoise(0f, randomStart + elapsed * 10f) - 0.5f) * shakeMagnitude;

            mainCamera.transform.position = new Vector3(x, ogPosition.y, z);

            elapsed += Time.unscaledDeltaTime;
            yield return null;
        }
        // Reset camera position after shake
        mainCamera.transform.position = ogPosition;
    }
}
