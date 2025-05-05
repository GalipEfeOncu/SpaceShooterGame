using UnityEngine;
using UnityEngine.SceneManagement;

public class SampleSceneLoad : MonoBehaviour
{
    public void SampleSceneLoader()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("SampleScene");
    }

    public void ExitTheGame()
    {
        Application.Quit();
    }
}
