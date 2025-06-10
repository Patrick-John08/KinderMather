using UnityEngine;

public class HourBox3 : MonoBehaviour
{
    public GameObject HourSnaps, HourBlue, Hour, blue2, zero;
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
            blue2.SetActive(true);
            zero.SetActive(true);
            Debug.Log("done");
        }
    }
}
