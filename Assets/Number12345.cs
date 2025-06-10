using UnityEngine;

public class Number12345 : MonoBehaviour
{
    public GameObject ZeroSnaps, ZeroBlue, Zero;
    public Number12345Count count;
    public int setCount;
    private bool hasCounted = false;

    private void OnTriggerEnter(Collider other)
    {
        if (!hasCounted && other.gameObject == Zero)
        {
            hasCounted = true;

            ZeroSnaps.SetActive(true);
            Zero.SetActive(false);
            count.SetZeroTrue(setCount);
            ZeroBlue.SetActive(false);

            Debug.Log("done");
        }
    }
}
