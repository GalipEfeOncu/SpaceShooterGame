using UnityEngine;
using UnityEngine.SceneManagement;

public class StartingSceneLoader : MonoBehaviour
{
    public void MainMenuLoader()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("StartingScene");
    }
}
