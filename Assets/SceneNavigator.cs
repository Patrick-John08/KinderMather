using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class SceneNavigator : MonoBehaviour
{
    public void MoveToMain_Menu()
    {
        StartCoroutine(LoadScene("MainMenu"));
    }



    public void MoveToTutorial()
    {

        StartCoroutine(LoadScene("Tutorial"));

    }
    public void MoveToScene1_Tutorial()
    {
        StartCoroutine(LoadScene("Scene1_Tutorial"));
    }

    public void MoveToScene1_1()
    {
        StartCoroutine(LoadScene("Scene1_1"));
    }


    public void ExitGame()
    {
        Application.Quit();
    }

    IEnumerator LoadScene(string sceneName)
    {

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(sceneName);

        asyncLoad.allowSceneActivation = false;

        asyncLoad.allowSceneActivation = true;

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

    }
}
