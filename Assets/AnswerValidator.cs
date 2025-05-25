using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class AnswerValidator : MonoBehaviour
{
    private int correctAnswer;
    private GameObject currentNumber;
    private XRGrabInteractable grabInteractable;

    public void SetCorrectAnswer(int answer)
    {
        correctAnswer = answer;
    }

    private void OnTriggerEnter(Collider other)
    {
        NumberCheck numberCheck = other.GetComponent<NumberCheck>();
        grabInteractable = other.GetComponent<XRGrabInteractable>();

        if (numberCheck != null && grabInteractable != null)
        {
            currentNumber = other.gameObject;

            // Subscribe to the release event
            grabInteractable.selectExited.AddListener(OnNumberReleased);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == currentNumber)
        {
            Debug.Log("Number removed from answer zone.");

            if (grabInteractable != null)
            {
                grabInteractable.selectExited.RemoveListener(OnNumberReleased);
            }

            currentNumber = null;
            grabInteractable = null;
        }
    }

    private void OnNumberReleased(SelectExitEventArgs args)
    {
        if (currentNumber == null) return;

        NumberCheck numberCheck = currentNumber.GetComponent<NumberCheck>();
        if (numberCheck != null)
        {
            int placedNumber = numberCheck.numberValue;

            if (placedNumber == correctAnswer)
            {
                Debug.Log("✅ Correct Answer!");
            }
            else
            {
                Debug.Log("❌ Wrong Answer!");
            }
        }

        if (grabInteractable != null)
        {
            grabInteractable.selectExited.RemoveListener(OnNumberReleased);
        }
    }
}
