using UnityEngine;
using System.Collections.Generic;

public class NumberRandomizer : MonoBehaviour
{
    public Transform[] numberPositions;
    public GameObject[] numberObjects;

    private void Start()
    {
        ShuffleNumbers();
    }

    private void ShuffleNumbers()
    {
        List<Transform> availablePositions = new List<Transform>(numberPositions);

        for (int i = 0; i < availablePositions.Count; i++)
        {
            int randomIndex = Random.Range(i, availablePositions.Count);
            Transform temp = availablePositions[i];
            availablePositions[i] = availablePositions[randomIndex];
            availablePositions[randomIndex] = temp;
        }

        for (int i = 0; i < numberObjects.Length; i++)
        {
            Quaternion originalRotation = numberObjects[i].transform.rotation;
            
            numberObjects[i].transform.position = availablePositions[i].position;
            numberObjects[i].transform.rotation = originalRotation;
        }
    }
}
