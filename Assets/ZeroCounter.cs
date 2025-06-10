using UnityEngine;

public class ZeroCount : MonoBehaviour
{
    private bool[] Zero = new bool[1];
    public TutorialScene1Manager canvas;
    // Call this method with the index (0, 1, or 2) to set it to true
    public void SetZeroTrue(int index)
    {
        if (index >= 0 && index < Zero.Length)
        {
            Zero[index] = true;

            if (AllTrue())
            {
                Debug.Log("DONE NA PO");
                canvas.ShowNumbersCanvas();
            }
        }
        else
        {
            Debug.LogWarning("Invalid index");
        }
    }

    private bool AllTrue()
    {
        foreach (bool flag in Zero)
        {
            if (!flag)
                return false;
        }
        return true;
    }
}
