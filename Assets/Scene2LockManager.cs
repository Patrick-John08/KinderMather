using UnityEngine;
using UnityEngine.UI;

public class Scene2LockManager : MonoBehaviour
{
    public Image Scene2Image;
    public Image Scene3Image;
    public Image Scene2Lock;
    public Image Scene3Lock;
    public Button Scene2Button;
    public Button Scene3Button;
    public string Scene2_1_Name = "Scene2_1";
    public string Scene2_2_Name = "Scene2_2";
    public string Scene2_3_Name = "Scene2_3";
    
    private void Start()
    {
        UpdateSceneLocks();
    }

    void UpdateSceneLocks()
    {
        int Scene2_1_Stars = PlayerPrefs.GetInt(Scene2_1_Name + "_stars", 0);
        int Scene2_2_Stars = PlayerPrefs.GetInt(Scene2_2_Name + "_stars", 0);
        int Scene2_3_Stars = PlayerPrefs.GetInt(Scene2_3_Name + "_stars", 0);

        bool isScene2Locked = Scene2_1_Stars != 3;
        bool isScene3Locked = Scene2_1_Stars != 3 || Scene2_2_Stars != 3;

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
