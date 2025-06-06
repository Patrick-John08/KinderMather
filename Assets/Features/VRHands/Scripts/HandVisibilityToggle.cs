using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class HandVisibilityToggle : MonoBehaviour
{
    [SerializeField] private XRBaseInteractor handInteractor;

    private SkinnedMeshRenderer handModel;
    private bool isGrabbed = false;

    private void Start()
    {
        handModel = GetComponentInChildren<SkinnedMeshRenderer>();

        // Safety checks
        if (handInteractor != null)
        {
            handInteractor.selectEntered.AddListener(OnGrab);
            handInteractor.selectExited.AddListener(OnLetGo);
        }
    }

    private void Update()
    {
        handModel.enabled = !isGrabbed;
    }

    private void OnLetGo(SelectExitEventArgs arg0)
    {
        isGrabbed = false;
    }

    private void OnGrab(SelectEnterEventArgs arg0)
    {
        isGrabbed = true;
    }
}
