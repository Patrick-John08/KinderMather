using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;

public class SnapZoneManager : MonoBehaviour
{
    public GameObject[] snapZones;
    private int currentSnapZoneIndex = 0;

    public string mainMenuSceneName = "Main Menu Scene";
    private Slider progressBar;

    public GameObject[] grayStars;
    public GameObject[] yellowStars;
    public GameTimer gameTimer;

    public GameObject leftHand;
    public GameObject rightHand;

    private XRRayInteractor leftHandRay;
    private XRRayInteractor rightHandRay;
    public GameObject playerMovement;
    public RecenterPosition recenterPosition;
    public GameObject gameEndCanvas;
    private TextMeshPro endGameText;
    public Button nextButton;
    public Button retryButton;

    private void Start()
    {
        GameObject progressBarObject = GameObject.FindGameObjectWithTag("ProgressBar");
        if (progressBarObject != null)
        {
            progressBar = progressBarObject.GetComponent<Slider>();
            progressBar.maxValue = snapZones.Length;
            progressBar.value = 0;
        }
        else
        {
            Debug.LogWarning("⚠ ProgressBar not found! Make sure it has the 'ProgressBar' tag.");
        }

        UpdateProgressUI();
    }

    public void InitializeSnapZones()
    {
        foreach (var zone in snapZones)
        {
            zone.SetActive(false);
        }

        currentSnapZoneIndex = 0;
        if (snapZones.Length > 0)
        {
            snapZones[0].SetActive(true);
        }

        UpdateProgressUI();
    }

    public void OnNumberSnapped(int numberValue)
    {
        if (numberValue == currentSnapZoneIndex)
        {
            snapZones[currentSnapZoneIndex].SetActive(false);
            currentSnapZoneIndex++;

            UpdateProgressUI();
            if (currentSnapZoneIndex < snapZones.Length)
            {
                snapZones[currentSnapZoneIndex].SetActive(true);
            }
            else
            {
                if (gameEndCanvas != null)
                {
                    gameTimer.StopTimer();
                    EndGame();
                }
            }
        }
    }

    private void UpdateProgressUI()
    {
        if (progressBar != null)
        {
            progressBar.value = currentSnapZoneIndex;
        }
    }

    public void DisplayStars()
    {
        GameObject endGameObject = GameObject.FindGameObjectWithTag("EndGameText");
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        if (endGameObject != null)
        {
            endGameText = endGameObject.GetComponent<TextMeshPro>();
        }

        if (grayStars.Length != 3 || yellowStars.Length != 3)
        {
            return;
        }

        foreach (var star in grayStars)
        {
            star.SetActive(true);
        }

        int totalProgress = snapZones.Length;
        int starsEarned = Mathf.FloorToInt((float)currentSnapZoneIndex / totalProgress * 3);

        if (starsEarned != 3)
        {
            endGameText.text = "TRY AGAIN!";
            retryButton.gameObject.SetActive(true);
            nextButton.gameObject.SetActive(false);
        }
        else
        {
            endGameText.text = "GOOD JOB!";
            if (sceneName == "Scene1_3" || sceneName == "Scene2_3" || sceneName == "Scene3_3")
            {
                retryButton.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(false);
            }
            else
            {
                retryButton.gameObject.SetActive(false);
                nextButton.gameObject.SetActive(true);
            }
        }

        for (int i = 0; i < starsEarned; i++)
        {
            yellowStars[i].SetActive(true);
            AnimateStar(yellowStars[i], i * 0.5f);
        }

        PlayerPrefs.SetInt(sceneName + "_stars", starsEarned);
        PlayerPrefs.Save();
    }

    private void AnimateStar(GameObject star, float delay)
    {
        star.transform.localScale = Vector3.zero;
        LeanTween.scale(star, Vector3.one, 0.5f)
            .setEase(LeanTweenType.easeOutBounce)
            .setDelay(delay);
    }

    public void EndGame()
    {
        if (recenterPosition != null)
        {
            DisablePlayerMovement(true);
            recenterPosition.Recenter();
        }

        leftHandRay = leftHand.GetComponent<XRRayInteractor>();
        rightHandRay = rightHand.GetComponent<XRRayInteractor>();

        if (leftHandRay != null) leftHandRay.enabled = true;
        if (rightHandRay != null) rightHandRay.enabled = true;

        if (gameEndCanvas != null)
        {
            gameEndCanvas.SetActive(true);
        }

        DisplayStars();
    }

    private void DisablePlayerMovement(bool disable)
    {
        if (playerMovement != null)
        {
            playerMovement.SetActive(!disable);
        }
    }
}
