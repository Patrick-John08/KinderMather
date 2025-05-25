using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapZoneValidator : MonoBehaviour
{
    public int correctNumber;
    public SnapZoneManager snapZoneManager;
    public GameObject thisDropZone;
    public AudioSource audioSource;
    public AudioClip numberSound;

    private bool isInsideSnapZone = false;

    private void Start()
    {
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
            audioSource.playOnAwake = false;
            audioSource.loop = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Number"))
        {
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                isInsideSnapZone = true;
                grabInteractable.selectExited.AddListener((interaction) => OnObjectReleased(other, grabInteractable));
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Number"))
        {
            XRGrabInteractable grabInteractable = other.GetComponent<XRGrabInteractable>();
            if (grabInteractable != null)
            {
                isInsideSnapZone = false;
                grabInteractable.selectExited.RemoveListener((interaction) => OnObjectReleased(other, grabInteractable));
            }
        }
    }

    private void OnObjectReleased(Collider other, XRGrabInteractable grabInteractable)
    {
        NumberCheck numberCheck = other.GetComponent<NumberCheck>();
        Rigidbody objectRigidbody = other.GetComponent<Rigidbody>();

        if (isInsideSnapZone && numberCheck != null && numberCheck.numberValue == correctNumber)
        {
            other.transform.SetParent(null);
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
            grabInteractable.enabled = false;

            if (objectRigidbody != null)
            {
                objectRigidbody.isKinematic = true;
            }

            snapZoneManager.OnNumberSnapped(correctNumber);
            PlayNumberSound();

            if (thisDropZone != null)
            {
                thisDropZone.SetActive(false);
            }
        }
    }

    private void PlayNumberSound()
    {
        if (numberSound != null)
        {
            audioSource.PlayOneShot(numberSound);
            Debug.Log($"🎤 Playing sound for number {correctNumber}: {numberSound.name}");
        }
        else
        {
            Debug.LogError($"❌ Missing sound for number {correctNumber} in {gameObject.name}!");
        }
    }
}
