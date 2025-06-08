using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class MainCanvas : MonoBehaviour
{
    public GameObject objectToToggle;

    private bool lastAButtonState = false;

    void Update()
    {
        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        if (rightHandDevice.isValid)
        {
            if (rightHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isAButtonPressed))
            {
                if (isAButtonPressed && !lastAButtonState)
                {
                    ToggleObject();
                }
                lastAButtonState = isAButtonPressed;
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
