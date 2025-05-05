using UnityEngine;
using UnityEngine.UI;

public class UIAspectAdjuster : MonoBehaviour
{
    [SerializeField] private CanvasScaler canvasScaler;
    [SerializeField] private float targetAspect = 9f / 16f;

    void Start()
    {
        AdjustUI();
    }

    void Update()
    {
        AdjustUI();
    }

    void AdjustUI()
    {
        float currentAspect = (float)Screen.width / (float)Screen.height;
        if (currentAspect != targetAspect)
        {
            canvasScaler.referenceResolution = new Vector2(960, 1728);
            canvasScaler.matchWidthOrHeight = 0.5f;
        }
    }
}
