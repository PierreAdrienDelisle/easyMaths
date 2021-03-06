﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class GameSystemCalcul : MonoBehaviour
{
    public TMP_Text currentCalcul;
    public TMP_InputField resultField;

    public string gamemode;
    public GameObject calculGameObj;
    private NewCalcul calculScript;
    private NewTableCalcul calculTableScript;
    private string resExpected;


    public GameObject scoreGameObj;
    private ScoreUpdate scoreUpdate;

    public GameObject wrongImage;
    public GameObject correctImage;
    public AudioSource WrongAudio;
    public AudioSource CorrectAudio;

    public TMP_Text nbCorrectText;
    public TMP_Text nbWrongText;
    public TMP_Text timerText;
    public int nbCorrect;
    public int nbWrong;
    private bool displayingResult;

    private float timer;
    public GameObject calculResults;
    public GameObject calculElements;


    public TMP_Text scoreResult;
    public TMP_Text nbCorrectResult;
    public TMP_Text nbWrongResult;

    public GameObject calculDigits;
    private Button[] digitButtons;

    public NewRecord newRecordScript;

    // Start is called before the first frame update
    private void Awake()
    {
        timer = PlayerPrefs.GetInt("timer", 60);
        timer -= Time.deltaTime;
        timerText.text = (timer).ToString("0");
        
    }
    void Start()
    {
        nbCorrect = 0;
        nbWrong = 0;
        scoreUpdate = scoreGameObj.GetComponent<ScoreUpdate>();
        if (gamemode == "calcul")
        {
            calculScript = calculGameObj.GetComponent<NewCalcul>();
            calculScript.randomCalcul();
            currentCalcul.text = calculScript.calculQuestion;
        }
        else if (gamemode == "table")
        {
            calculTableScript = calculGameObj.GetComponent<NewTableCalcul>();
            calculTableScript.randomCalcul();
            currentCalcul.text = calculTableScript.calculQuestion;
        }

        resultField.text = "";
        digitButtons = calculDigits.GetComponentsInChildren<Button>();

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = (timer).ToString("0");
        if (timer < 0)
        {
            //get var
            calculElements.SetActive(false);
            calculResults.SetActive(true);
            scoreResult.text = "Score: " + scoreUpdate.score.ToString();
            nbCorrectResult.text = nbCorrect.ToString();
            nbWrongResult.text = nbWrong.ToString();
            if (gamemode == "calcul")
            {
                newRecordScript.isCalculRecord(scoreUpdate.score);

            }
            else if (gamemode == "table")
            {
                newRecordScript.isTableRecord(scoreUpdate.score);
            }
        }
        if (!displayingResult)
        {
            if(gamemode == "calcul")
            {
                resExpected = calculScript.resultExpected.ToString();
            }else if(gamemode == "table")
            {
                resExpected = calculTableScript.resultExpected.ToString();
            }

            if (resExpected.Contains(resultField.text)) // result match
            {
                if (resultField.text == resExpected)
                {
                    displayingResult = true;
                    //trigger correct event
                    StartCoroutine(CorrectEvent(1, correctImage));
                }

            }
            else if (resultField.text == "")
            {
                // not yet answered
            }
            else
            {
                //trigger wrong event
                displayingResult = true;
                StartCoroutine(WrongEvent(1, wrongImage));

            }
        }
    }

    IEnumerator answerDisplay(float time, GameObject image)
    {
        image.SetActive(true);
        yield return new WaitForSeconds(time);
        image.SetActive(false);
        
    }


    IEnumerator WrongEvent(float time, GameObject image)
    {
        StartCoroutine(answerDisplay(1, wrongImage));
        WrongAudio.Play();
        freezeInput();
        resultField.text = resultField.text + "=> "+ resExpected;
        yield return new WaitForSeconds(1.5f);
        resultField.text = "";
        if(gamemode == "calcul")
        {
            calculScript.randomCalcul();
            currentCalcul.text = calculScript.calculQuestion;
        }
        else if(gamemode == "table")
        {
            calculTableScript.randomCalcul();
            currentCalcul.text = calculTableScript.calculQuestion;
        }
        resultField.text = "";
        enableInput();
        scoreUpdate.wrongAnswer();
        nbWrong += 1;
        nbWrongText.text = nbWrong.ToString();
        displayingResult = false;

    }

    IEnumerator CorrectEvent(float time, GameObject image)
    {
        StartCoroutine(answerDisplay(1, correctImage));
        CorrectAudio.Play();
        freezeInput();
        yield return new WaitForSeconds(0.5f);
        if (gamemode == "calcul")
        {
            calculScript.randomCalcul();
            currentCalcul.text = calculScript.calculQuestion;
        }
        else if (gamemode == "table")
        {
            calculTableScript.randomCalcul();
            currentCalcul.text = calculTableScript.calculQuestion;
        }
        resultField.text = "";
        enableInput();
        scoreUpdate.correctAnswer();
        nbCorrect += 1;
        nbCorrectText.text = nbCorrect.ToString();
        displayingResult = false;
    }

    private void freezeInput()
    {
        foreach (Button digitButton in digitButtons)
        {
            digitButton.enabled = false;
        }
    }

    private void enableInput()
    {
        foreach (Button digitButton in digitButtons)
        {
            digitButton.enabled = true;
        }
    }

}
