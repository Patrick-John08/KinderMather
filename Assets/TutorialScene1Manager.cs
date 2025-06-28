using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialScene1Manager : MonoBehaviour
{
    public GameObject welcomeCanvas, zeroCanvas, numbersCanvas, doneCanvas, MainCanvas;
    public GameObject welcomeCanvasDL, zeroCanvasDL, numbersCanvasDL, doneCanvasDL;
    public GameObject zeroGuide, numbersGuide;

    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);
        welcomeCanvasDL.SetActive(true);
        zeroCanvas.SetActive(false);
        numbersCanvas.SetActive(false);
        doneCanvas.SetActive(false);
        zeroGuide.SetActive(false);
        numbersGuide.SetActive(false);
    }

    public void ShowZeroCanvas()
    {
        ShowDialogue(zeroCanvas);
        welcomeCanvasDL.SetActive(false);
        zeroCanvasDL.SetActive(true);
        MainCanvas.SetActive(true);
        zeroGuide.SetActive(true);
    }

    public void ShowNumbersCanvas()
    {
        ShowDialogue(numbersCanvas);
        zeroCanvasDL.SetActive(false);
        numbersCanvasDL.SetActive(true);
        MainCanvas.SetActive(true);
        numbersGuide.SetActive(true);
    }

    public void ShowDoneCanvas()
    {
        ShowDialogue(doneCanvas);
        numbersCanvasDL.SetActive(false);
        doneCanvasDL.SetActive(true);
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
