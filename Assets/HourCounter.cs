using UnityEngine;

public class HourCounter : MonoBehaviour
{
    private bool[] hourFlags = new bool[3];

    public void SetTowelTrue(int index)
    {
        if (index >= 0 && index < hourFlags.Length)
        {
            hourFlags[index] = true;

            if (AllTrue())
            {
                Debug.Log("DONE NA PO");

            }
        }
        else
        {
            Debug.LogWarning("Invalid towel index");
        }
    }

    private bool AllTrue()
    {
        foreach (bool flag in hourFlags)
        {
            if (!flag)
                return false;
        }
        return true;
    }
}
