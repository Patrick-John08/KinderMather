using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialScene3Manager : MonoBehaviour
{
    public GameObject welcomeCanvas, MainCanvas, Hour, Minute, Done;
    public GameObject welcomeCanvasDL, HourDL, MinuteDL, DoneDL;
    // Start is called before the first frame update
    void Start()
    {
        welcomeCanvas.SetActive(true);
        welcomeCanvasDL.SetActive(true);
        Hour.SetActive(false);
        Minute.SetActive(false);
        Done.SetActive(false);
    }

    public void ShowHourCanvas()
    {
        ShowDialogue(Hour);
        welcomeCanvasDL.SetActive(false);
        HourDL.SetActive(true);
        MainCanvas.SetActive(true);
    }

    public void ShowMinuteCanvas()
    {
        ShowDialogue(Minute);
        HourDL.SetActive(false);
        MinuteDL.SetActive(true);
        MainCanvas.SetActive(true);
    }

    public void ShowDoneCanvas()
    {
        ShowDialogue(Done);
        DoneDL.SetActive(true);
        MinuteDL.SetActive(false);
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
