using UnityEngine;
using UnityEngine.UI;

public class SceneLockManager : MonoBehaviour
{
    public Image Scene2Image;
    public Image Scene3Image;
    public Image Scene2Lock;
    public Image Scene3Lock;
    public Button Scene2Button;
    public Button Scene3Button;
    
    public string Scene1_1_Name = "Scene1_1";
    public string Scene1_2_Name = "Scene1_2";
    public string Scene1_3_Name = "Scene1_3";
    public string Scene2_1_Name = "Scene2_1";
    public string Scene2_2_Name = "Scene2_2";
    public string Scene2_3_Name = "Scene2_3";
    public string Scene3_1_Name = "Scene3_1";
    public string Scene3_2_Name = "Scene3_2";
    public string Scene3_3_Name = "Scene3_3";

    private void Start()
    {
        UpdateSceneLocks();
    }

    void UpdateSceneLocks()
    {
        bool isScene2Unlocked = HasAllStars(new string[] { Scene1_1_Name, Scene1_2_Name, Scene1_3_Name });

        bool isScene3Unlocked = isScene2Unlocked && HasAllStars(new string[] { Scene2_1_Name, Scene2_2_Name, Scene2_3_Name });

        LockScene(Scene2Image, Scene2Lock, Scene2Button, !isScene2Unlocked);
        LockScene(Scene3Image, Scene3Lock, Scene3Button, !isScene3Unlocked);
    }

    bool HasAllStars(string[] levelNames)
    {
        foreach (string level in levelNames)
        {
            if (PlayerPrefs.GetInt(level + "_stars", 0) < 3)
            {
                return false;
            }
        }
        return true;
    }

    void LockScene(Image sceneImage, Image lockImage, Button sceneButton, bool isLocked)
    {
        if (sceneImage != null)
        {
            sceneImage.color = isLocked ? Color.gray : Color.white;
        }
        if (lockImage != null)
        {
            lockImage.gameObject.SetActive(isLocked);
        }
        if (sceneButton != null)
        {
            sceneButton.interactable = !isLocked;
        }
    }
}
