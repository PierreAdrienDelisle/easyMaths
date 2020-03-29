using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class StartGame : MonoBehaviour
{

    public float timeLeft = 5.0f;
    private float savedTimeScale;

    public GameObject calculSystem;
    public GameObject calculDigits;
    private GameSystem gameScript;
    private DigitScript[] digitsScripts;

    public TMP_Text startText;
    public GameObject resultInput;

    private void Start()
    {
        gameScript = calculSystem.GetComponent<GameSystem>();
        digitsScripts = calculDigits.GetComponentsInChildren<DigitScript>();
        foreach (DigitScript digitScript in digitsScripts)
        {
            digitScript.enabled = false;
        }
        gameScript.enabled = false;
        resultInput.SetActive(false);

    }
    void Update()
    {
        timeLeft -= Time.deltaTime;
        startText.text = (timeLeft).ToString("0");
        if (timeLeft < 0){
            gameScript.enabled = true;
            digitsScripts = calculDigits.GetComponentsInChildren<DigitScript>();
            foreach (DigitScript digitScript in digitsScripts)
            {
                digitScript.enabled = false;
            }
            resultInput.SetActive(true);
            startText.gameObject.SetActive(false);
        }
    }

}