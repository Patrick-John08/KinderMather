using UnityEngine;

public class AutoAddSettingsManager : MonoBehaviour
{
    private void Awake()
    {
        if (SettingsManager.Instance == null)
        {
            GameObject settingsManagerObj = new GameObject("SettingsManager");
            settingsManagerObj.AddComponent<SettingsManager>();
        }
    }
}
