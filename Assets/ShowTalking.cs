using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTalking : MonoBehaviour
{
    public GameObject walking, talking;
    public AudioSource talk;
    public GameObject Menu;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == walking)
        {
            walking.SetActive(false);
            talking.SetActive(true);
            talk.Play();

            // Start coroutine to wait until audio finishes
            StartCoroutine(WaitForAudioToEnd());
        }
    }

    IEnumerator WaitForAudioToEnd()
    {
        // Wait while the audio is playing
        yield return new WaitWhile(() => talk.isPlaying);
        Menu.SetActive(true);
        // Audio finished
        Debug.Log("done");
    }
}
