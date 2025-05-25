using UnityEngine;
using UnityEngine.UI;

public class TutorialIntroManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introSound;

    public Button gameStartButton;
    public Button goBackButton;

    void Start()
    {
        gameStartButton.interactable = false;
        goBackButton.interactable = false;

        if (audioSource != null)
        {
            float savedVolume = PlayerPrefs.GetFloat("volume", 10f);
            Debug.Log("Saved Volume: " + savedVolume);
            audioSource.volume = savedVolume / 10f;
        }

        Light sceneLight = GameObject.FindWithTag("SceneLight")?.GetComponent<Light>();

        if (sceneLight != null)
        {
            float savedBrightness = PlayerPrefs.GetFloat("brightness", 1f);
            Debug.Log("Saved Brightness: " + savedBrightness);
            sceneLight.intensity = savedBrightness;
        }

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }

        PlayIntroSound();
    }

    private void PlayIntroSound()
    {
        if (introSound != null)
        {
            audioSource.PlayOneShot(introSound);

            Invoke(nameof(EnableButtons), introSound.length);
        }
        else
        {
            EnableButtons();
        }
    }

    private void EnableButtons()
    {
        gameStartButton.interactable = true;
        goBackButton.interactable = true;
    }
}