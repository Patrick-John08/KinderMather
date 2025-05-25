using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class FootstepSound : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] footstepSounds;
    public ActionBasedContinuousMoveProvider moveProvider;
    public float stepInterval = 0.5f;

    private float stepTimer = 0f;

    void Update()
    {
        if (moveProvider == null || audioSource == null || footstepSounds.Length == 0)
        {
            return;
        }

        Vector2 input = moveProvider.leftHandMoveAction.action.ReadValue<Vector2>();
        bool isMoving = input.magnitude > 0.1f;

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if (stepTimer <= 0)
            {
                PlayFootstep();
                stepTimer = stepInterval;
            }
        }
    }

    void PlayFootstep()
    {
        if (footstepSounds.Length > 0)
        {
            audioSource.PlayOneShot(footstepSounds[Random.Range(0, footstepSounds.Length)]);
        }
    }
}
