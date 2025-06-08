using UnityEngine;
using UnityEngine.XR;
using System.Collections.Generic;

public class VRInputDetector : MonoBehaviour
{
    private InputDevice leftController;
    private InputDevice rightController;

    private bool leftJoystickUsed = false;
    private bool rightJoystickUsed = false;
    private bool buttonAUsed = false;
    private bool buttonBUsed = false;
    private bool buttonXUsed = false;
    private bool buttonYUsed = false;
    private bool leftTriggerUsed = false;
    private bool rightTriggerUsed = false;
    private bool leftGripUsed = false;
    private bool rightGripUsed = false;

    //
    public GameObject WalkX, WalkY;
    public GameObject MenuX, MenuY;
    public GameObject RTriggerX, RTriggerY;
    public GameObject LTriggerX, LTriggerY;
    public GameObject RGrabX, RGrabY;
    public GameObject LGrabX, LGrabY;
    public GameObject TurnX, TurnY;
    public GameObject HideX, HideY;

    void Start()
    {
        TryInitializeControllers();
    }

    void TryInitializeControllers()
    {
        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesAtXRNode(XRNode.LeftHand, devices);
        if (devices.Count > 0)
            leftController = devices[0];

        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        if (devices.Count > 0)
            rightController = devices[0];
    }

    void Update()
    {
        if (!leftController.isValid || !rightController.isValid)
            TryInitializeControllers();

        CheckInputs();
    }

    void CheckInputs()
    {
        // Joysticks
        Vector2 leftStick, rightStick;
        if (!leftJoystickUsed && leftController.TryGetFeatureValue(CommonUsages.primary2DAxis, out leftStick) && leftStick.magnitude > 0.1f)
        {
            leftJoystickUsed = true;
            Debug.Log("Left Joystick used");
            WalkX.SetActive(false);
            WalkY.SetActive(true);
        }
        if (!rightJoystickUsed && rightController.TryGetFeatureValue(CommonUsages.primary2DAxis, out rightStick) && rightStick.magnitude > 0.1f)
        {
            rightJoystickUsed = true;
            Debug.Log("Right Joystick used");
            TurnX.SetActive(false);
            TurnY.SetActive(true);
        }

        // Buttons A, B (Right controller), X, Y (Left controller)
        bool buttonValue;
        if (!buttonAUsed && rightController.TryGetFeatureValue(CommonUsages.primaryButton, out buttonValue) && buttonValue)
        {
            buttonAUsed = true;
            Debug.Log("Button A pressed");
            HideX.SetActive(false);
            HideY.SetActive(true);
        }
        if (!buttonXUsed && leftController.TryGetFeatureValue(CommonUsages.primaryButton, out buttonValue) && buttonValue)
        {
            buttonXUsed = true;
            Debug.Log("Button X pressed");
            MenuX.SetActive(false);
            MenuY.SetActive(true);
        }
        // Triggers
        float triggerValue;
        if (!leftTriggerUsed && leftController.TryGetFeatureValue(CommonUsages.trigger, out triggerValue) && triggerValue > 0.1f)
        {
            leftTriggerUsed = true;
            Debug.Log("Left Trigger pressed");
            LTriggerX.SetActive(false);
            LTriggerY.SetActive(true);
        }
        if (!rightTriggerUsed && rightController.TryGetFeatureValue(CommonUsages.trigger, out triggerValue) && triggerValue > 0.1f)
        {
            rightTriggerUsed = true;
            Debug.Log("Right Trigger pressed");
            RTriggerX.SetActive(false);
            RTriggerY.SetActive(true);
        }

        // Grabs (Grip buttons)
        float gripValue;
        if (!leftGripUsed && leftController.TryGetFeatureValue(CommonUsages.grip, out gripValue) && gripValue > 0.1f)
        {
            leftGripUsed = true;
            Debug.Log("Left Grip used");
            LGrabX.SetActive(false);
            LGrabY.SetActive(true);
        }
        if (!rightGripUsed && rightController.TryGetFeatureValue(CommonUsages.grip, out gripValue) && gripValue > 0.1f)
        {
            rightGripUsed = true;
            Debug.Log("Right Grip used");
            RGrabX.SetActive(false);
            RGrabY.SetActive(true);
        }
    }
}
