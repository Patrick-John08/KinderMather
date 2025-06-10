using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FruitCounterTutorial : MonoBehaviour
{
    public int counter = 0;
    private HashSet<GameObject> countedFruits = new HashSet<GameObject>();
    public TextMeshPro counterText; // This is for TextMeshPro 3D (not UI)
    public GameObject fruit1, fruit2;
    public GameObject guide2, seven, guide1, finalguide;
    public TutorialScene2Manager canvas;

    void Start()
    {
        fruit1.SetActive(false);
        fruit2.SetActive(false);
        guide2.SetActive(false);
        seven.SetActive(false);
        finalguide.SetActive(false);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("fruit") && !countedFruits.Contains(other.gameObject))
        {
            counter++;
            countedFruits.Add(other.gameObject);
            counterText.text = "FRUITS IN BASKET: " + counter;
            Debug.Log("Fruit counted: " + counter);

            if (counter == 5)
            {
                Debug.Log("5");
                fruit1.SetActive(true);
                fruit2.SetActive(true);
                guide2.SetActive(true);
                guide1.SetActive(false);
                canvas.ShowSecondDigitCanvas();
            }
            else if(counter == 7)
            {
                seven.SetActive(true);
                guide2.SetActive(false);
                finalguide.SetActive(true);
                Debug.Log("Congrats");
                canvas.ShowDoneCanvas();
            }
        }
    }
}
