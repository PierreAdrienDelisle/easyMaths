using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class loadScene : MonoBehaviour
{
    public void calculScene()
    {
        SceneManager.LoadScene("CalculScene");
    }

    public void menuScene()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void menuSceneGM()
    {
        DontDestroyOnLoad(gameObject);
        SceneManager.LoadScene("MenuScene");
        GameObject[] goArray = SceneManager.GetSceneByName("MenuScene").GetRootGameObjects();
        Debug.Log(SceneManager.GetSceneByName("MenuScene").name);
        foreach(GameObject go in goArray)
        {
           if(go.name == "GameModeMenu")
            {
                go.SetActive(true);
            }else if(go.name == "MainMenu")
            {
                go.SetActive(false);
            }
            Debug.Log("Test");
        }
        GameObject.Destroy(gameObject);
    }
}
