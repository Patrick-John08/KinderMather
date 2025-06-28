using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialCanvasManager : MonoBehaviour
{
    public GameObject WelcomeMessage, Controllers, Grab,MainCanvas, Done;
    public GameObject WelcomeMessageDL, ControllersDL, GrabDL, DoneDL;
    public GameObject controllersChecklist, ControllerList, GrabList;
    public GameObject welcomeAudio, controlAudio, grabAudio, doneAudio;

    void Start()
    {
        WelcomeShow();
        Controllers.SetActive(false);
        controllersChecklist.SetActive(false);
        Grab.SetActive(false);
        ControllerList.SetActive(false);
        GrabList.SetActive(false);
        Done.SetActive(false);
    }

    public void WelcomeShow()
    {
        ShowDialogue(WelcomeMessage);
        WelcomeMessageDL.SetActive(true);
        welcomeAudio.SetActive(true);
        MainCanvas.SetActive(true);
    }

    public void ControllersShow()
    {
        ShowDialogue(Controllers);
        WelcomeMessageDL.SetActive(false);
        ControllersDL.SetActive(true);
        welcomeAudio.SetActive(false);
        controlAudio.SetActive(true);
        MainCanvas.SetActive(true);
        StartCoroutine(ActivateControllersAfterDelay(1f));
    }

    private IEnumerator ActivateControllersAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        ControllerList.SetActive(true);
        controllersChecklist.SetActive(true);
    }

    public void GrabShow()
    {
        ShowDialogue(Grab);
        ControllersDL.SetActive(false);
        grabAudio.SetActive(true);
        GrabDL.SetActive(true);
        controlAudio.SetActive(false);
        MainCanvas.SetActive(true);
    }

    public void GrabClose()
    {
        Grab.SetActive(false);
        ControllerList.SetActive(false);
        GrabList.SetActive(true);
    }

    public void DoneShow()
    {
        ShowDialogue(Done);
        GrabDL.SetActive(false);
        grabAudio.SetActive(false);
        doneAudio.SetActive(true);
        DoneDL.SetActive(true);
        MainCanvas.SetActive(true);
        ControllerList.SetActive(false);
    }


    private void ShowDialogue(GameObject dialogue)
    {
        WelcomeMessage.SetActive(false);
        Controllers.SetActive(false);
        Grab.SetActive(false);
        Done.SetActive(false);
        dialogue.SetActive(true);
    }
}
