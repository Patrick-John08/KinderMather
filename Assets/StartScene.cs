using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR;

public class StartScene : MonoBehaviour
{
    private InputDevice targetDevice;

    void Start()
    {
        targetDevice = GetDeviceWithCharacteristic(InputDeviceCharacteristics.Controller | InputDeviceCharacteristics.Right);
    }

    void Update()
    {
        if (targetDevice.isValid)
        {
            bool startButtonPressed;
            if (targetDevice.TryGetFeatureValue(CommonUsages.primaryButton, out startButtonPressed) && startButtonPressed)
            {
                ChangeScene();
            }
        }
    }

    private InputDevice GetDeviceWithCharacteristic(InputDeviceCharacteristics characteristics)
    {
        var devices = new List<InputDevice>();
        InputDevices.GetDevicesWithCharacteristics(characteristics, devices);
        return devices.Count > 0 ? devices[0] : default;
    }

    private void ChangeScene()
    {
        SceneManager.LoadScene("Scene1");
    }
}
