using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class GameIntroManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip introSound;

    public Button gameStartButton;
    public Button goBackButton;

    public TextMeshPro introText;
    [TextArea]
    public string fullIntroText;
    public float typingSpeed = 0.04f;

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

        StartCoroutine(PlayTTSAndType());
    }

    private IEnumerator PlayTTSAndType()
    {
        if (introText != null)
            introText.text = "";

        if (introSound != null)
            audioSource.PlayOneShot(introSound);

        yield return StartCoroutine(TypeText(fullIntroText));

        if (introSound != null)
            yield return new WaitForSeconds(introSound.length);

        EnableButtons();
    }

    private IEnumerator TypeText(string textToType)
    {
        if (introText == null || string.IsNullOrEmpty(textToType)) yield break;

        introText.text = "";

        foreach (char letter in textToType)
        {
            introText.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }

    private void EnableButtons()
    {
        gameStartButton.interactable = true;
        goBackButton.interactable = true;
    }
}
