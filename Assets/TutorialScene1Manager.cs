using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialScene1Manager : MonoBehaviour
{
    public GameObject welcomeCanvas, zeroCanvas, numbersCanvas, doneCanvas, MainCanvas;
    public GameObject zeroGuide, numbersGuide;

    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);
        zeroCanvas.SetActive(false);
        numbersCanvas.SetActive(false);
        doneCanvas.SetActive(false);
        zeroGuide.SetActive(false);
        numbersGuide.SetActive(false);
    }

    public void ShowZeroCanvas()
    {
        ShowDialogue(zeroCanvas);
        MainCanvas.SetActive(true);
        zeroGuide.SetActive(true);
    }

    public void ShowNumbersCanvas()
    {
        ShowDialogue(numbersCanvas);
        MainCanvas.SetActive(true);
        numbersGuide.SetActive(true);
    }

    public void ShowDoneCanvas()
    {
        ShowDialogue(doneCanvas);
        MainCanvas.SetActive(true);
    }

    private void ShowDialogue(GameObject dialogue)
    {
        welcomeCanvas.SetActive(false);
        zeroCanvas.SetActive(false);
        numbersCanvas.SetActive(false);
        doneCanvas.SetActive(false);
        dialogue.SetActive(true);
    }
}
