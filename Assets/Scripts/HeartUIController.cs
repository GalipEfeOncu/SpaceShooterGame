using UnityEngine;
using UnityEngine.UI;

public class HeartUIController : MonoBehaviour
{
    [SerializeField] DestroyPlayer destroyPlayer;

    [SerializeField] RawImage heart1, heart2, heart3, emptyHeart1, emptyHeart2, emptyHeart3;

    int playerHeal;
    private void Update()
    {
        playerHeal = destroyPlayer.GetterPlayerHeal();
        if (playerHeal == 2)
        {
            heart1.gameObject.SetActive(false);
            emptyHeart1.gameObject.SetActive(true);
        }
        else if (playerHeal == 1)
        {
            heart2.gameObject.SetActive(false);
            emptyHeart2.gameObject.SetActive(true);
        }
        else if (playerHeal == 0)
        {
            heart3.gameObject.SetActive(false);
            emptyHeart3.gameObject.SetActive(true);
        }
    }
}