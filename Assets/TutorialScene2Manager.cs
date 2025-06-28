using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialScene2Manager : MonoBehaviour
{
    public GameObject welcomeCanvas, firstDigit, SecondDigit, Done, fruits, MainCanvas;
    public GameObject welcomeCanvasDL, firstDigitDL, SecondDigitDL, DoneDL;
    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);
        welcomeCanvasDL.SetActive(true);
        firstDigit.SetActive(false);
        SecondDigit.SetActive(false);
        Done.SetActive(false);
        fruits.SetActive(false);
        MainCanvas.SetActive(true);
    }

    public void ShowfirstDigitCanvas()
    {
        ShowDialogue(firstDigit);
        firstDigitDL.SetActive(true);
        welcomeCanvasDL.SetActive(false);
        MainCanvas.SetActive(true);
        fruits.SetActive(true);
    }

    public void ShowSecondDigitCanvas()
    {
        ShowDialogue(SecondDigit);
        firstDigitDL.SetActive(false);
        SecondDigitDL.SetActive(true);
        MainCanvas.SetActive(true);
    }

    public void ShowDoneCanvas()
    {
        ShowDialogue(Done);
        SecondDigitDL.SetActive(false);
        DoneDL.SetActive(true);
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
