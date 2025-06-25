using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRemover : MonoBehaviour
{
    public GameObject canvas;
    public AudioSource dialogue;
    private bool hasDeactivated = false;

    void Update()
    {
        // Check if audio has finished and canvas is still active
        if (!dialogue.isPlaying && canvas.activeSelf && !hasDeactivated)
        {
            canvas.SetActive(false);
            hasDeactivated = true;
        }
    }
}
