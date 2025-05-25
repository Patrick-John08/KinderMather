using UnityEngine;
using TMPro;
using UnityEngine.XR.Interaction.Toolkit;

public class GameTimer : MonoBehaviour
{
    public float timeRemaining = 181f;
    private bool timerIsRunning = false;

    private TextMeshPro timerText;
    public GameObject gameEndCanvas;
    public SnapZoneManager snapZoneManager;
    public RandomEquationGenerator randomEquationGenerator;
    public SnapZoneManagerScene3 snapZoneManagerScene3;
    public GameObject leftHand;
    public GameObject rightHand;

    private XRRayInteractor leftHandRay;
    private XRRayInteractor rightHandRay;
    public GameObject playerMovement;

    public AudioSource audioSource;
    public AudioClip tickingSound;

    public RecenterPosition recenterPosition;

    private void Start()
    {
        GameObject textObject = GameObject.FindGameObjectWithTag("TimerText");

        if (textObject != null)
        {
            timerText = textObject.GetComponent<TextMeshPro>();
        }

        if (timerText == null)
        {
            Debug.LogError("TimerText object NOT found in the scene! Check the name and tag.");
        }

        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                if (timeRemaining <= 0)
                {
                    timeRemaining = 0;
                    timerIsRunning = false;
                    TimerEnded();
                }
                UpdateTimerDisplay();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        if (timerText != null)
        {
            int minutes = Mathf.FloorToInt(timeRemaining / 60);
            int seconds = Mathf.FloorToInt(timeRemaining % 60);
            timerText.text = $"{minutes:00}:{seconds:00}";

            if (timeRemaining <= 29 && timeRemaining > 0)
            {
                timerText.color = Color.red;

                if (!audioSource.isPlaying)
                {
                    audioSource.clip = tickingSound;
                    audioSource.loop = true;
                    audioSource.Play();
                }
            }
            else if (timeRemaining <= 0 && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }

    private void TimerEnded()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (recenterPosition != null)
        {
            recenterPosition.Recenter();
            DisablePlayerMovement(true);
        }

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }

        leftHandRay = leftHand.GetComponent<XRRayInteractor>();
        rightHandRay = rightHand.GetComponent<XRRayInteractor>();

        if (leftHandRay != null) leftHandRay.enabled = true;
        if (rightHandRay != null) rightHandRay.enabled = true;

        if (gameEndCanvas != null)
        {
            gameEndCanvas.SetActive(true);
        }

        if (sceneName.StartsWith("Scene1", System.StringComparison.OrdinalIgnoreCase))
        {
            if (snapZoneManager != null)
            {
                snapZoneManager.DisplayStars();
            }
        }
        else if (sceneName.StartsWith("Scene2", System.StringComparison.OrdinalIgnoreCase))
        {
            if (randomEquationGenerator != null)
            {
                randomEquationGenerator.DisplayStars();
            }
        }
        else if (sceneName.StartsWith("Scene3", System.StringComparison.OrdinalIgnoreCase))
        {
            if (snapZoneManagerScene3 != null)
            {
                snapZoneManagerScene3.DisplayStars();
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void StopTimer()
    {
        timerIsRunning = false;
    }

    private void DisablePlayerMovement(bool disable)
    {
        if (playerMovement != null)
        {
            playerMovement.SetActive(!disable);
        }
    }
}
