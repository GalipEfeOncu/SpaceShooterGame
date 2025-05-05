using System.Collections;
using UnityEngine;

public class DestroyAsteroid : MonoBehaviour
{
    [Header("Asteroid Properties")]
    [SerializeField] private GameObject asteroidExplosion; // Explosion effect prefab
    private int asteroidHeal; // Health of the asteroid
    private int asteroidWave;

    [Header("Script References")]
    public CreateAsteroid createAsteroid;

    [Header("UI References")]
    [SerializeField] private GameObject gameOverMenu;

    int counter = 1;

    public void SetHeal(int heal)
    {
        asteroidHeal = heal; // Set asteroid's health from outside
    }

    public void SetWave(int wave)
    {
        asteroidWave = wave;
    }

    private void OnTriggerEnter(Collider other)
    {
        int waveCount = createAsteroid.getAsteroidWave();
        if (other.CompareTag("Bolt"))
        {
            asteroidHeal--;
            Destroy(other.gameObject);  // Destroy the bullet

            if (asteroidHeal == 0)
            {
                Instantiate(asteroidExplosion, transform.position, transform.rotation);
                Destroy(gameObject);  // Destroy the asteroid

                int currentWave = createAsteroid.getAsteroidWave();
                if (asteroidWave == 5)
                {
                    createAsteroid.asteroidCount--;
                    Debug.Log("Asteroid was destroyed: " + createAsteroid.asteroidCount);
                }
            }
        }
    }

    private void Update()
    {
        StartCoroutine(GameOverMenu());        
    }

    IEnumerator GameOverMenu()
    {
        if (createAsteroid.asteroidCount == 0 && createAsteroid.allAsteroidsSpawned && counter == 1)
        {
            gameOverMenu.SetActive(true);
            counter--;
            yield return new WaitForSecondsRealtime(1f);
            Time.timeScale = 0f;
        }
    }
}
