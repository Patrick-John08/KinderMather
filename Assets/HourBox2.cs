using UnityEngine;

public class HourBox2 : MonoBehaviour
{
    public GameObject HourSnaps, HourBlue, Hour, blue1, hour1, hour2, minute1, minute2;
    public HourCounter count;
    public int setCount;
    private bool hasCounted = false;


    private void OnTriggerEnter(Collider other)
    {
        if (!hasCounted && other.gameObject == Hour)
        {
            hasCounted = true;
            hour1.SetActive(false);
            hour2.SetActive(false);
            minute1.SetActive(true);
            minute2.SetActive(true);
            HourSnaps.SetActive(true);
            Hour.SetActive(false);
            count.SetTowelTrue(setCount);
            HourBlue.SetActive(false);
            blue1.SetActive(true);
            Debug.Log("done");
        }
    }
}
