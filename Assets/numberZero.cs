using UnityEngine;

public class NumberZero : MonoBehaviour
{
    public GameObject ZeroSnaps, ZeroBlue, Zero;
    public ZeroCount count;
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
