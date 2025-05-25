using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class GameStartManager : MonoBehaviour
{
    public GameObject gameStartCanvas;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject playerMovement;
    public GameTimer gameTimer;

    private XRRayInteractor leftHandRay;
    private XRRayInteractor rightHandRay;
    public SnapZoneManager snapZoneManager;
    public SnapZoneManagerScene3 snapZoneManagerScene3;

    void Start()
    {
        leftHandRay = leftHand.GetComponent<XRRayInteractor>();
        rightHandRay = rightHand.GetComponent<XRRayInteractor>();

        gameStartCanvas.SetActive(true);
        DisablePlayerMovement(true);
    }

    public void StartGame()
    {
        gameStartCanvas.SetActive(false);

        if (leftHandRay != null) leftHandRay.enabled = false;
        if (rightHandRay != null) rightHandRay.enabled = false;

        DisablePlayerMovement(false);

        if (gameTimer != null)
        {
            gameTimer.StartTimer();
        }

        if (snapZoneManager != null)
        {
            snapZoneManager.InitializeSnapZones();
        }

        if (snapZoneManagerScene3 != null)
        {
            snapZoneManagerScene3.InitializeSnapZones();
        }
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu Scene");
    }

    private void DisablePlayerMovement(bool disable)
    {
        if (playerMovement != null)
        {
            playerMovement.SetActive(!disable);
        }
    }
}
