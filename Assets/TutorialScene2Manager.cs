using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialScene2Manager : MonoBehaviour
{
    public GameObject welcomeCanvas, firstDigit, SecondDigit, Done, fruits, MainCanvas;

    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);
        firstDigit.SetActive(false);
        SecondDigit.SetActive(false);
        Done.SetActive(false);
        fruits.SetActive(false);
        MainCanvas.SetActive(true);
    }

    public void ShowfirstDigitCanvas()
    {
        ShowDialogue(firstDigit);
        MainCanvas.SetActive(true);
        fruits.SetActive(true);
    }

    public void ShowSecondDigitCanvas()
    {
        ShowDialogue(SecondDigit);
        MainCanvas.SetActive(true);
    }

    public void ShowDoneCanvas()
    {
        ShowDialogue(Done);
        MainCanvas.SetActive(true);
    }

    private void ShowDialogue(GameObject dialogue)
    {
        welcomeCanvas.SetActive(false);
        firstDigit.SetActive(false);
        SecondDigit.SetActive(false);
        Done.SetActive(false);
        dialogue.SetActive(true);
    }
}
