using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TutorialStartmanager : MonoBehaviour
{
    public GameObject gameStartCanvas;
    public GameObject nextCanvas;
    public GameObject leftHand;
    public GameObject rightHand;
    public GameObject playerMovement;

    private XRRayInteractor leftHandRay;
    private XRRayInteractor rightHandRay;

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
    }

    public void BackToMainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Main Menu Scene");
    }

    public void ShowNextCanvas()
    {
        if (gameStartCanvas != null)
            gameStartCanvas.SetActive(false);

        if (nextCanvas != null)
            nextCanvas.SetActive(true);

        DisablePlayerMovement(false);
    }

    private void DisablePlayerMovement(bool disable)
    {
        if (playerMovement != null)
        {
            playerMovement.SetActive(!disable);
        }
    }
}
