using UnityEngine.XR.Interaction.Toolkit;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SnapZoneManagerScene3 : MonoBehaviour
{
    public List<SnapZoneScene3> allSnapZones;
    public ClockController clockController;

    private int currentRound = 0;
    public int totalRounds = 3;

    private int correctHour;
    private int correctMinute;
    private int correctAnswer = 0;
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

    public void InitializeSnapZones()
    {
        (correctHour, correctMinute) = clockController.GetRandomTimeFromLastScene();

        int startIndex = currentRound * 3;
        int endIndex = startIndex + 3;

        for (int i = startIndex; i < endIndex; i++)
        {
            if (i < allSnapZones.Count)
            {
                if (i == startIndex)
                    allSnapZones[i].correctNumber = correctHour;
                else if (i == startIndex + 1)
                    allSnapZones[i].correctNumber = correctMinute / 10;
                else if (i == startIndex + 2)
                    allSnapZones[i].correctNumber = correctMinute % 10;
            }
        }

        ActivateRound(currentRound);
    }

    public void ActivateRound(int round)
    {
        foreach (var snapZone in allSnapZones)
        {
            snapZone.gameObject.SetActive(false);
        }

        int startIndex = round * 3;
        int endIndex = startIndex + 3;

        for (int i = startIndex; i < endIndex; i++)
        {
            if (i < allSnapZones.Count)
            {
                allSnapZones[i].gameObject.SetActive(true);
                allSnapZones[i].ResetSnapZone();
            }
        }
    }

    public void CheckSnapZoneCompletion()
    {
        Debug.Log("CheckSnapZoneCompletion called");

        int baseIndex = currentRound * 3;
        List<int> submittedNumbers = new List<int>();

        for (int i = baseIndex; i < baseIndex + 3; i++)
        {
            var value = allSnapZones[i].GetSnappedValue();
            if (value == null)
            {
                Debug.LogWarning($"SnapZone {i} has no snapped value.");
                return;
            }

            submittedNumbers.Add((int)value);
        }

        string correctTime = $"{correctHour:D2}:{correctMinute:D2}";
        string inputTime = string.Format("{0:D2}:{1:D2}", submittedNumbers[0], submittedNumbers[1] * 10 + submittedNumbers[2]);

        Debug.Log($"Correct Time: {correctTime}");
        Debug.Log($"Input Time: {inputTime}");

        if (inputTime == correctTime)
        {
            correctAnswer++;
            currentRound++;

            if (currentRound < totalRounds)
            {

                (correctHour, correctMinute) = clockController.GetRandomTimeForScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
                clockController.UpdateClock(correctHour, correctMinute);

                InitializeSnapZones();
            }
            else
            {
                gameTimer.StopTimer();
                EndGame();
            }
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

        int starsEarned = Mathf.Min(correctAnswer, totalRounds);

        if (starsEarned != totalRounds)
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