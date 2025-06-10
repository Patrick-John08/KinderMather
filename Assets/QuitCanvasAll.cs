using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CanvasToggleALL : MonoBehaviour
{
    public static InputFeatureUsage<bool> xButton = CommonUsages.primaryButton;   // Left X
    public static InputFeatureUsage<bool> aButton = CommonUsages.primaryButton;   // Right A

    public GameObject MainCanvas; // Changed from Canvas to GameObject
    public GameObject QuitCanvas; // X Button

    private bool isScriptActive = true;

    private bool previousXButtonState = false;
    private bool previousAButtonState = false;

    private InputDevice leftHandDevice;
    private InputDevice rightHandDevice;

    private void Start()
    {
        InitializeXRInput();
        MainCanvas.SetActive(true);
        QuitCanvas.SetActive(false);
    }

    private void InitializeXRInput()
    {
        var devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Left, devices);
        if (devices.Count > 0) leftHandDevice = devices[0];

        devices.Clear();

        InputDevices.GetDevicesWithCharacteristics(InputDeviceCharacteristics.Right, devices);
        if (devices.Count > 0) rightHandDevice = devices[0];
    }

    private void Update()
    {
        if (!isScriptActive) return;

        bool xPressed = false;
        bool aPressed = false;

        if (leftHandDevice.isValid)
        {
            leftHandDevice.TryGetFeatureValue(xButton, out xPressed);
        }

        if (rightHandDevice.isValid)
        {
            rightHandDevice.TryGetFeatureValue(aButton, out aPressed);
        }

        HandleXButtonInput(xPressed);
        HandleAButtonInput(aPressed);
    }

    private void HandleXButtonInput(bool isPressed)
    {
        if (isPressed && !previousXButtonState)
        {
            QuitCanvas.SetActive(!QuitCanvas.activeSelf);
        }
        previousXButtonState = isPressed;
    }


    private void HandleAButtonInput(bool isPressed)
    {
        if (isPressed && !previousAButtonState)
        {
            MainCanvas.SetActive(!MainCanvas.activeSelf);
        }
        previousAButtonState = isPressed;
    }

    public void DeactivateScript()
    {
        QuitCanvas.SetActive(false);
        MainCanvas.SetActive(false);
        isScriptActive = false;
    }
}
