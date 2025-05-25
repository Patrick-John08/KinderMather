using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;
using TMPro;

public class RandomEquationGenerator : MonoBehaviour
{
    [Header("Number GameObjects")]
    public GameObject[] numbers;

    [Header("Operator GameObjects")]
    public GameObject plusSign;
    public GameObject minusSign;
    public GameObject equalSign;

    [Header("Equation Positions")]
    public Transform NUM1_POS;
    public Transform OPERAND_POS;
    public Transform NUM2_POS;
    public Transform EQUAL_POS;

    [Header("Basket System")]
    public Transform basket;
    public GameObject basketObject;

    [Header("TextMeshPro Fruits Count")]
    private TextMeshPro fruitsCountText;

    private List<GameObject> instantiatedObjects = new List<GameObject>();
    private int correctAnswer;
    private int currentFruitCount = 0;

    private int minNumber = 1;
    private int maxNumber;

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

    public Transform[] fruits;

    private List<Vector3> fruitPositions = new List<Vector3>();
    private List<Quaternion> fruitRotations = new List<Quaternion>();

    private int correctAnswerCount = 0;

    private Coroutine correctAnswerCoroutine;

    private void Start()
    {
        GameObject textObject = GameObject.FindGameObjectWithTag("FruitCounter");

        if (textObject != null)
        {
            fruitsCountText = textObject.GetComponent<TextMeshPro>();
        }

        if (fruitsCountText == null)
        {
            Debug.LogError("FruitCounter object NOT found in the scene! Check the name and tag.");
        }

        if (numbers == null || numbers.Length == 0)
        {
            Debug.LogError("Numbers array is empty or not assigned!");
            return;
        }

        maxNumber = numbers.Length - 1;
        HideAll();
        GenerateEquation();
        SaveFruitsPositions();
    }

    void HideAll()
    {
        foreach (var number in numbers)
        {
            if (number) number.SetActive(false);
        }
        if (plusSign) plusSign.SetActive(false);
        if (minusSign) minusSign.SetActive(false);
        if (equalSign) equalSign.SetActive(false);
    }

    void GenerateEquation()
    {
        foreach (var obj in instantiatedObjects)
        {
            if (obj != null)
            {
                Destroy(obj);
            }
        }

        instantiatedObjects.Clear();

        if (numbers == null || numbers.Length == 0) return;

        int num1, num2;
        GameObject selectedOperand;

        do
        {
            num1 = Random.Range(minNumber, maxNumber);
            num2 = Random.Range(minNumber, maxNumber);

            selectedOperand = Random.value > 0.5f ? plusSign : minusSign;

            if (selectedOperand == plusSign)
            {
                correctAnswer = num1 + num2;
            }
            else
            {
                correctAnswer = num1 - num2;
            }
        }
        while (correctAnswer < minNumber || correctAnswer > maxNumber);

        instantiatedObjects.Add(Instantiate(numbers[num1], NUM1_POS.position, NUM1_POS.rotation, NUM1_POS));
        instantiatedObjects.Add(Instantiate(selectedOperand, OPERAND_POS.position, OPERAND_POS.rotation, OPERAND_POS));
        instantiatedObjects.Add(Instantiate(numbers[num2], NUM2_POS.position, NUM2_POS.rotation, NUM2_POS));
        instantiatedObjects.Add(Instantiate(equalSign, EQUAL_POS.position, EQUAL_POS.rotation, EQUAL_POS));

        foreach (var obj in instantiatedObjects)
        {
            obj.SetActive(true);
        }

        currentFruitCount = 0;
        fruitsCountText.text = $"FRUITS IN BASKET: {currentFruitCount}";
        fruitsCountText.color = Color.red;

        ResetFruitCounters();

        Debug.Log($"Correct Answer: {correctAnswer}");
    }

    public void UpdateFruitCount(int change)
    {
        currentFruitCount += change;

        fruitsCountText.text = $"FRUITS IN BASKET: {currentFruitCount}";

        if (currentFruitCount == correctAnswer)
        {
            fruitsCountText.color = Color.green;
            Debug.Log("✅ Correct! The number of fruits in the basket matches the answer.");
            correctAnswerCount++;

            if (correctAnswerCount >= 3)
            {
                gameTimer.StopTimer();
                EndGame();
            }
            else
            {
                if (correctAnswerCoroutine != null)
                {
                    StopCoroutine(correctAnswerCoroutine);
                    correctAnswerCoroutine = null;
                }

                correctAnswerCoroutine = StartCoroutine(CorrectAnswerRoutine());
            }
        }
        else
        {
            if (correctAnswerCoroutine != null)
            {
                StopCoroutine(correctAnswerCoroutine);
                correctAnswerCoroutine = null;
            }

            fruitsCountText.color = Color.red;

            if (currentFruitCount > correctAnswer)
            {
                Debug.Log("❌ Too many fruits! Remove some from the basket.");
            }
            else
            {
                Debug.Log("❌ Not enough fruits! Add more to the basket.");
            }
        }
    }

    private IEnumerator CorrectAnswerRoutine()
    {
        yield return new WaitForSeconds(5f);
        ResetFruitPositions();
        Start();
    }

    private void SaveFruitsPositions()
    {
        fruitPositions.Clear();
        fruitRotations.Clear();

        foreach (var fruit in fruits)
        {
            if (fruit != null)
            {
                fruitPositions.Add(fruit.position);
                fruitRotations.Add(fruit.rotation);
            }
        }
    }

    private void ResetFruitPositions()
    {
        for (int i = 0; i < fruits.Length; i++)
        {
            if (fruits[i] != null && fruitPositions.Count > i && fruitRotations.Count > i)
            {
                fruits[i].position = fruitPositions[i];
                fruits[i].rotation = fruitRotations[i];
            }
        }
    }

    private void ResetFruitCounters()
    {
        FruitCounter[] fruitCounters = FindObjectsOfType<FruitCounter>();
        foreach (var fruitCounter in fruitCounters)
        {
            fruitCounter.ResetCountedState();
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

        int starsEarned = 0;
        if (correctAnswerCount == 1) starsEarned = 1;
        if (correctAnswerCount == 2) starsEarned = 2;
        if (correctAnswerCount == 3) starsEarned = 3;

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