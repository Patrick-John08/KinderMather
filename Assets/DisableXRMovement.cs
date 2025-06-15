using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class DisableXRMovement : MonoBehaviour
{
    public ContinuousMoveProviderBase moveProvider; // Or use TeleportationProvider if teleport-based
    public ActionBasedController leftController;
    public ActionBasedController rightController;

    public void DisableMovement()
    {
        moveProvider.enabled = false;

        // Optionally disable input on both controllers
        leftController.enableInputActions = false;
        rightController.enableInputActions = false;
    }

    public void EnableMovement()
    {
        moveProvider.enabled = true;

        leftController.enableInputActions = true;
        rightController.enableInputActions = true;
    }
}
