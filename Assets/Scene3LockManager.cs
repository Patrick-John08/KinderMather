using UnityEngine;
using UnityEngine.UI;

public class Scene3LockManager : MonoBehaviour
{
    public Image Scene2Image;
    public Image Scene3Image;
    public Image Scene2Lock;
    public Image Scene3Lock;
    public Button Scene2Button;
    public Button Scene3Button;
    public string Scene3_1_Name = "Scene3_1";
    public string Scene3_2_Name = "Scene3_2";
    public string Scene3_3_Name = "Scene3_3";
    
    private void Start()
    {
        UpdateSceneLocks();
    }

    void UpdateSceneLocks()
    {
        int Scene3_1_Stars = PlayerPrefs.GetInt(Scene3_1_Name + "_stars", 0);
        int Scene3_2_Stars = PlayerPrefs.GetInt(Scene3_2_Name + "_stars", 0);
        int Scene3_3_Stars = PlayerPrefs.GetInt(Scene3_3_Name + "_stars", 0);

        bool isScene2Locked = Scene3_1_Stars != 3;
        bool isScene3Locked = Scene3_1_Stars != 3 || Scene3_2_Stars != 3;

        LockScene(Scene2Image, Scene2Lock, Scene2Button, isScene2Locked);
        LockScene(Scene3Image, Scene3Lock, Scene3Button, isScene3Locked);
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
