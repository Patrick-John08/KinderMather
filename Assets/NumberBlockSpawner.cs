using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class NumberBlockSpawner : MonoBehaviour
{
    public List<GameObject> numberBlockPrefabs; // 0 to 12 blocks

    // This will hold the initial positions of each block
    private List<Vector3> blockPositions = new List<Vector3>();

    private void Start()
    {
        // Automatically capture the initial position of each block when the game starts
        SaveInitialPositions();
    }

    private void SaveInitialPositions()
    {
        blockPositions.Clear(); // Clear previous data

        // Iterate over the numberBlockPrefabs and save their initial positions
        for (int i = 0; i < numberBlockPrefabs.Count; i++)
        {
            GameObject prefab = numberBlockPrefabs[i];

            // Assume the blocks are already placed in the scene in their correct positions
            Vector3 initialPosition = prefab.transform.position; // Capture the current position from the scene
            blockPositions.Add(initialPosition);
        }
    }

    public void SpawnNewBlockOnCorrectSnap(int number)
    {
        if (number < 0 || number >= numberBlockPrefabs.Count)
        {
            Debug.LogWarning("Invalid number for spawning.");
            return;
        }

        GameObject prefab = numberBlockPrefabs[number];
        Vector3 spawnPosition = blockPositions[number]; // Use the saved initial position
        GameObject clone = Instantiate(prefab, spawnPosition, Quaternion.identity);

        // Ensure that the clone is interactable (XRGrabInteractable)
        XRGrabInteractable grabInteractable = clone.GetComponent<XRGrabInteractable>();
        if (grabInteractable != null)
        {
            grabInteractable.enabled = true;
        }

        // Ensure that Rigidbody and BoxCollider are on the clone
        Rigidbody rigidbody = clone.GetComponent<Rigidbody>();
        if (rigidbody == null)
        {
            rigidbody = clone.AddComponent<Rigidbody>(); // Add Rigidbody if it's missing
        }

        BoxCollider boxCollider = clone.GetComponent<BoxCollider>();
        if (boxCollider == null)
        {
            boxCollider = clone.AddComponent<BoxCollider>(); // Add BoxCollider if it's missing
        }

        // Set the correct number on the cloned block
        NumberBlock numberBlockScript = clone.GetComponent<NumberBlock>();
        if (numberBlockScript != null)
        {
            numberBlockScript.number = number; // Set the number to match the spawned block
        }

        // Activate the clone
        clone.SetActive(true);
    }
}
