using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene3Manager : MonoBehaviour
{
    public GameObject welcomeCanvas, MainCanvas, Hour, Minute, Done;

    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);
        Hour.SetActive(false);
        Minute.SetActive(false);
        Done.SetActive(false);
    }

    public void ShowHourCanvas()
    {
        ShowDialogue(Hour);
        MainCanvas.SetActive(true);
    }

    public void ShowMinuteCanvas()
    {
        ShowDialogue(Minute);
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
        Hour.SetActive(false);
        Minute.SetActive(false);
        Done.SetActive(false);
        dialogue.SetActive(true);
    }
}
