using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FruitCounter : MonoBehaviour
{
    private RandomEquationGenerator equationGenerator;
    private bool inBasket = false;
    private bool counted = false;
    private XRGrabInteractable grabInteractable;

    private void Start()
    {
        equationGenerator = FindObjectOfType<RandomEquationGenerator>();
        if (equationGenerator == null)
        {
            Debug.LogError("❌ RandomEquationGenerator not found in scene!");
        }

        grabInteractable = GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.AddListener(OnObjectReleased);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            inBasket = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Basket"))
        {
            inBasket = false;
        }
    }

    private void OnObjectReleased(SelectExitEventArgs args)
    {
        if (inBasket && !counted)
        {

            equationGenerator.UpdateFruitCount(1);
            counted = true;
        }
        else if (!inBasket && counted)
        {

            equationGenerator.UpdateFruitCount(-1);
            counted = false;
        }
    }

    private void OnDestroy()
    {
        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnObjectReleased);
        }
    }

    public void ResetCountedState()
    {
        counted = false;
    }
}