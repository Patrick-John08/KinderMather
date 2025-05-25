using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public static SettingsManager Instance;

    public float volume = 10f;
    public float brightness = 1f;

    // public float movementSpeed = 10f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // Load saved values or default
            volume = PlayerPrefs.GetFloat("volume", 10f);
            brightness = PlayerPrefs.GetFloat("brightness", 1f);
            // movementSpeed = PlayerPrefs.GetFloat("movement_speed", 10f);

            ApplySettings();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetVolume(float val)
    {
        volume = val;
        AudioListener.volume = volume / 10f;
        PlayerPrefs.SetFloat("volume", volume);
        PlayerPrefs.Save(); // Save immediately

        Debug.Log("Saved Volume: " + volume);

        float savedVolume = PlayerPrefs.GetFloat("volume", 10f);
        Debug.Log("Saved Volume: " + savedVolume);
    }

    public void SetBrightness(float val)
    {
        brightness = val;

        PlayerPrefs.SetFloat("brightness", brightness);
        PlayerPrefs.Save();

        Light sceneLight = GameObject.FindWithTag("SceneLight")?.GetComponent<Light>();

        if (sceneLight != null)
        {
            sceneLight.intensity = brightness;
        }
    }

    // public void SetMovementSpeed(float val)
    // {
    //     movementSpeed = val;

    //     PlayerPrefs.SetFloat("movement_speed", movementSpeed);
    //     PlayerPrefs.Save();
    // }

    private void ApplySettings()
    {
        SetVolume(volume);
        SetBrightness(brightness);
        // SetMovementSpeed(movementSpeed);
    }
}
