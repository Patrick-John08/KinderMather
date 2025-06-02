using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class QuitCanvasShow : MonoBehaviour
{
    public GameObject objectToToggle;

    private bool lastXButtonState = false;

    void Update()
    {
        InputDevice leftHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (leftHandDevice.isValid)
        {
            if (leftHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isXButtonPressed))
            {
                if (isXButtonPressed && !lastXButtonState)
                {
                    ToggleObject();
                }
                lastXButtonState = isXButtonPressed;
            }
        }
    }

    private void ToggleObject()
    {
        if (objectToToggle != null)
        {
            objectToToggle.SetActive(!objectToToggle.activeSelf);
        }
    }
}
