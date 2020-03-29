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
}
