using System.Collections;
using System.Threading;
using TMPro;
using UnityEngine;

public class CreateAsteroid : MonoBehaviour
{
    [Header("Asteroid Settings")]
    public GameObject[] asterodiPrefabs;
    private int asteroidSpawnCount = 2;
    private int asteroidHeal = 2;
    public int asteroidCount;
    public bool allAsteroidsSpawned = false;

    [Header("Wave Settings")]
    private int waveCount = 1;
    [SerializeField] private float startWait;
    [SerializeField] private float spawnWait;
    [SerializeField] private float waveDelay;

    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI waveText;

    [Header("Font Animation")]
    private float startFontSize = 0f;
    private float endFontSize = 250f;
    private float fontSizeDuration;


    private void Start()
    {
        fontSizeDuration = waveDelay / 2; // Set font size animation duration based on wave delay
        StartCoroutine(RandomAsteroidSpawner());
    }

    IEnumerator RandomAsteroidSpawner()
    {
        yield return new WaitForSecondsRealtime(startWait);  // Wait before starting the spawning process

        while (waveCount <= 5)
        {
            yield return StartCoroutine(WaveTextShower());  // Display wave text and wait for it to finish
            for (int i = 0; i < asteroidSpawnCount; i++)
            {
                yield return new WaitWhile(() => Time.timeScale == 0f); // Wait until the game is unpaused

                int randomIndex = Random.Range(0, asterodiPrefabs.Length); // Randomly select asteroid prefab
                float randomPosX = Random.Range(-3, 3); // Random X position within a defined range
                Vector3 randomPosition = new Vector3(randomPosX, 0, 7.8f); // Random position for asteroid spawn
                Quaternion rotation = Quaternion.identity;

                GameObject newAsteroid = Instantiate(asterodiPrefabs[randomIndex], randomPosition, rotation);
                DestroyAsteroid destroyAsteroid = newAsteroid.GetComponent<DestroyAsteroid>();
                destroyAsteroid.SetWave(waveCount);
                if (waveCount == 5)
                {
                    asteroidCount++;
                    Debug.Log("Asteroid was created: " + asteroidCount);
                }

                if (destroyAsteroid != null)
                {
                    destroyAsteroid.SetHeal(asteroidHeal); // Set the asteroid's health value
                    destroyAsteroid.createAsteroid = this;
                }

                yield return StartCoroutine(WaitWithPause(spawnWait)); // Wait between asteroid spawns, considering time scale
            }

            asteroidHeal++;  // Increase asteroid health for the next wave
            asteroidSpawnCount++;  // Increase asteroid count for the next wave
            waveCount++;  // Increase the wave count
        }
        allAsteroidsSpawned = true;
    }

    IEnumerator WaveTextShower()
    {
        waveText.text = "Wave " + waveCount; // Update wave text
        yield return new WaitForSecondsRealtime(waveDelay / 2);
        waveText.gameObject.SetActive(true);
        StartCoroutine(AnimateFontSize()); // Start the font size animation for the wave text
        yield return new WaitForSecondsRealtime(waveDelay / 2);
        waveText.gameObject.SetActive(false);
    }

    IEnumerator AnimateFontSize()
    {
        float elapsed = 0f;

        while (elapsed < fontSizeDuration)
        {
            elapsed += Time.deltaTime;
            float t = elapsed / fontSizeDuration;
            float currentSize = Mathf.Lerp(startFontSize, endFontSize, t); // Interpolate font size between start and end values
            waveText.fontSize = currentSize;
            yield return null;  // Wait for the next frame
        }

        waveText.fontSize = startFontSize; // Reset to the starting font size after animation completes
    }

    IEnumerator WaitWithPause(float time) // Waits for a given time but pauses the timer when the game is paused.
    {
        float elapsed = 0f;
        while (elapsed < time)
        {
            if (Time.timeScale > 0f) // If the game is unpaused
            {
                elapsed += Time.unscaledDeltaTime;
            }
            yield return null;
        }
    }

    public int getAsteroidWave()
    {
        return waveCount;
    }

}
