using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{

    public void calculScene()
    {
        SceneManager.LoadScene("CalculScene");
    }

    public void tableScene()
    {
        SceneManager.LoadScene("TableScene");
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

}