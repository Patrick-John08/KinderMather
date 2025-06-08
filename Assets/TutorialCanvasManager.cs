using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class TutorialCanvasManager : MonoBehaviour
{
    public GameObject WelcomeMessage, Controllers, Grab,MainCanvas, Done;
    public GameObject controllersChecklist, ControllerList, GrabList;

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
        MainCanvas.SetActive(true);
    }

    public void ControllersShow()
    {
        ShowDialogue(Controllers);
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
