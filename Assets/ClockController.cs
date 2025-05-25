using UnityEngine;

public class ClockController : MonoBehaviour
{
    public Transform hourNeedle;
    public Transform minuteNeedle;

    private void Start()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        (int h, int m) = GetRandomTimeForScene(sceneName);
        UpdateClock(h, m);

        string formattedTime = $"{h}:{m.ToString("D2")}";
    }

    public void UpdateClock(int hours, int minutes)
    {
        float hourRotation = (hours % 12) * 30f + (minutes * 0.5f) - 90f;
        float minuteRotation = (minutes * 6f) - 90f;

        hourNeedle.localRotation = Quaternion.Euler(0, 0, hourRotation);
        minuteNeedle.localRotation = Quaternion.Euler(0, 0, minuteRotation);
    }

    public (int, int) GetRandomTimeForScene(string sceneName)
    {
        int h = 12, m = 0;

        if (sceneName == "Scene3")
        {
            int[] allowedHours = { 1, 2, 3, 4, 5 };
            h = allowedHours[Random.Range(0, allowedHours.Length)];
            m = 0;
        }
        else if (sceneName == "Scene3_1")
        {
            int[] allowedHours = { 1, 2, 3, 4, 5 };
            h = allowedHours[Random.Range(0, allowedHours.Length)];
            m = 0;
        }
        else if (sceneName == "Scene3_2")
        {
            int[] allowedHours = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            h = allowedHours[Random.Range(0, allowedHours.Length)];
            m = 0;
        }
        else if (sceneName == "Scene3_3")
        {
            int[] allowedHours = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            h = allowedHours[Random.Range(0, allowedHours.Length)];
            m = 0;
        }

        return (h, m);
    }

    public (int, int) GetRandomTimeFromLastScene()
    {
        string sceneName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        var (h, m) = GetRandomTimeForScene(sceneName);
        UpdateClock(h, m);
        return (h, m);
    }
}
