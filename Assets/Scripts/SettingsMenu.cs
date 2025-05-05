using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    [Header("Audio Mixer")]
    [SerializeField] private AudioMixer audioMixer; // Main audio mixer for controlling volume

    [Header("Audio Text Displays")]
    [SerializeField] private TextMeshProUGUI audioMasterText;
    [SerializeField] private TextMeshProUGUI audioMusicText;
    [SerializeField] private TextMeshProUGUI audioSFXText;

    [Header("Audio Sliders")]
    [SerializeField] private Slider masterSlider;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSlider;

    [Header("UI References")]
    [SerializeField] private GameObject settings;


    private void Start()
    {
        // Load saved volume preferences or use default value of 1 (100%)
        float masterPrefs = PlayerPrefs.GetFloat("MasterPrefs", 1f);
        float musicPrefs = PlayerPrefs.GetFloat("MusicPrefs", 1f);
        float SFXPrefs = PlayerPrefs.GetFloat("SFXPrefs", 1f);

        // Set slider values without triggering callbacks
        masterSlider.SetValueWithoutNotify(masterPrefs);
        musicSlider.SetValueWithoutNotify(musicPrefs);
        SFXSlider.SetValueWithoutNotify(SFXPrefs);

        // Apply volume settings to audio mixer (converting linear 0-1 to dB scale)
        audioMixer.SetFloat("Master", Mathf.Log10(masterPrefs) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(musicPrefs) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXPrefs) * 20);

        // Update volume percentage text displays
        audioMasterText.text = (masterPrefs * 100).ToString("F0");
        audioMusicText.text = (musicPrefs * 100).ToString("F0");
        audioSFXText.text = (SFXPrefs * 100).ToString("F0");
    }

    private void Update()
    {
        // Toggle settings menu when Escape key is pressed
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!settings.gameObject.activeSelf)
            {
                settings.gameObject.SetActive(true);
                Time.timeScale = 0f;
            }
            else
            {
                settings.gameObject.SetActive(false);
                Time.timeScale = 1f;
            }
        }
    }

    /// Updates audio volumes and UI text when sliders are moved
    public void SoundManager()
    {
        // Calculate percentage values for display
        float masterValue = masterSlider.value * 100;
        float musicValue = musicSlider.value * 100;
        float SFXValue = SFXSlider.value * 100;

        // Update volume percentage text displays
        audioMasterText.text = masterValue.ToString("F0");
        audioMusicText.text = musicValue.ToString("F0");
        audioSFXText.text = SFXValue.ToString("F0");

        // Apply volume settings to audio mixer (converting linear 0-1 to dB scale)
        audioMixer.SetFloat("Master", Mathf.Log10(masterSlider.value) * 20);
        audioMixer.SetFloat("Music", Mathf.Log10(musicSlider.value) * 20);
        audioMixer.SetFloat("SFX", Mathf.Log10(SFXSlider.value) * 20);
    }

    /// Saves current volume settings to PlayerPrefs
    public void SaveSettings()
    {
        PlayerPrefs.SetFloat("MasterPrefs", masterSlider.value);
        PlayerPrefs.SetFloat("MusicPrefs", musicSlider.value);
        PlayerPrefs.SetFloat("SFXPrefs", SFXSlider.value);
        PlayerPrefs.Save(); // Immediately write to disk
    }
}
