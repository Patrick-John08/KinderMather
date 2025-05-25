using UnityEngine;

public class TimerPositioner : MonoBehaviour
{
    public Transform playerCamera;
    public RectTransform timerUI; 

    public float distanceFromFace = 1.5f;
    public Vector3 offset = new Vector3(0f, 0.8f, 0f);

    void Update()
    {
        if (playerCamera != null && timerUI != null)
        {
            timerUI.position = playerCamera.position + (playerCamera.forward * distanceFromFace) + offset;

            timerUI.LookAt(playerCamera);
            timerUI.Rotate(0, 180, 0);
        }
    }
}
