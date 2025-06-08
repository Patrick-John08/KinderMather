using UnityEngine;

public class TutorialChecklistManager : MonoBehaviour
{
    public GameObject[] objectsToCheck; // Assign objects in the Inspector
    public TutorialCanvasManager canvas;

    void Start()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            obj.SetActive(false);
        }
    }

    void Update()
    {
        if (AllObjectsActive())
        {
            Debug.Log("DONE GRAB");
            canvas.DoneShow();
        }
    }

    bool AllObjectsActive()
    {
        foreach (GameObject obj in objectsToCheck)
        {
            if (!obj.activeInHierarchy)  // Check if any object is inactive
            {
                return false;
            }
        }
        return true;
    }
}
