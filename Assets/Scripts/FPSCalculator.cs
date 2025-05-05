using TMPro;
using UnityEngine;

public class FPSCalculator : MonoBehaviour
{
    public TextMeshProUGUI avgFpsText;
    private float fps;
    private float elapsedTime = 0f;
    private int frameCount = 0;

    void Update()
    {
        // Accumulate unscaled time (doesn't depend on Time.timeScale, so it works during pause)
        elapsedTime += Time.unscaledDeltaTime;

        // Increment the frame count
        frameCount++;

        // Every 0.2 seconds, calculate and update the FPS value
        if (elapsedTime >= 0.2f)
        {
            // Calculate FPS by dividing frame count by elapsed time
            fps = frameCount / elapsedTime;

            // Update text
            avgFpsText.text = "FPS: " + fps.ToString("F0");

            // Reset variables
            elapsedTime = 0f;
            frameCount = 0;
        }
    }
}
