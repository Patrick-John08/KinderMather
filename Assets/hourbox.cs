using UnityEngine;

public class HourBox : MonoBehaviour
{
    public GameObject HourSnaps, HourBlue, Hour;
    public HourCounter count;
    public int setCount;
    private bool hasCounted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasCounted && other.gameObject == Hour)
        {
            hasCounted = true;

            HourSnaps.SetActive(true);
            Hour.SetActive(false);
            count.SetTowelTrue(setCount);
            HourBlue.SetActive(false);

            Debug.Log("done");
        }
    }
}
