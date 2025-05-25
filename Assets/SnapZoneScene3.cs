using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SnapZoneScene3 : MonoBehaviour
{
    public Transform snapPosition;
    private GameObject snappedObject;

    private XRSocketInteractor socketInteractor;
    private SnapZoneManagerScene3 manager;
    public int correctNumber;
    private NumberBlock snappedBlock;
    private NumberBlockSpawner blockSpawner;

    private void Awake()
    {
        blockSpawner = FindObjectOfType<NumberBlockSpawner>();
        socketInteractor = GetComponent<XRSocketInteractor>();
        manager = FindObjectOfType<SnapZoneManagerScene3>();
    }

    private void OnEnable()
    {
        socketInteractor.selectEntered.AddListener(OnSnapped);
        socketInteractor.selectExited.AddListener(OnRemoved);
    }

    private void OnDisable()
    {
        socketInteractor.selectEntered.RemoveListener(OnSnapped);
        socketInteractor.selectExited.RemoveListener(OnRemoved);
    }

    private void OnSnapped(SelectEnterEventArgs args)
    {
        snappedObject = args.interactableObject.transform.gameObject;
        var numberBlock = snappedObject.GetComponent<NumberBlock>();

        if (numberBlock != null && numberBlock.number == correctNumber)
        {
            Snap(numberBlock);
            snappedObject.transform.position = snapPosition.position;
            snappedObject.transform.rotation = snapPosition.rotation;

            snappedObject.GetComponent<XRGrabInteractable>().enabled = false;

            gameObject.SetActive(false);

            manager.CheckSnapZoneCompletion();
            blockSpawner.SpawnNewBlockOnCorrectSnap(correctNumber);
        }
        else
        {

            snappedObject = null;
        }
    }

    private void OnRemoved(SelectExitEventArgs args)
    {
        if (snappedObject != null)
        {

            gameObject.SetActive(true);
        }
        snappedObject = null;
    }

    public int? GetSnappedValue()
    {
        return snappedBlock != null ? (int?)snappedBlock.number : null;
    }

    public void ResetSnapZone()
    {
        if (snappedObject != null)
        {
            Destroy(snappedObject);
            snappedObject = null;
        }
        gameObject.SetActive(true);
    }

    public void Snap(NumberBlock block)
    {
        snappedBlock = block;
        Debug.Log($"SnapZone [{name}] snapped value: {block.number}");
    }
}