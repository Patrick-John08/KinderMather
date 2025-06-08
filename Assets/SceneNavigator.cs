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
    public void MoveToSuperFicial()
    {
        StartCoroutine(LoadScene("Superficial_Wounds"));
    }

    public void MoveToConcussion()
    {
        StartCoroutine(LoadScene("Concussion"));
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
