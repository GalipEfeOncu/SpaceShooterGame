using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    [SerializeField] private GameObject deathScreen;

    public void DeathScreenViewer()
    {
        deathScreen.SetActive(true);
    }
}
