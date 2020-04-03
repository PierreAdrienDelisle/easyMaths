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
    private Button[] digitButtons;

    public TMP_Text startText;
    public GameObject resultInput;

    private void Start()
    {
        gameScript = calculSystem.GetComponent<GameSystem>();
        digitButtons = calculDigits.GetComponentsInChildren<Button>();
        foreach (Button digitButton in digitButtons)
        {
            Debug.Log(digitButton + ": false");
            digitButton.enabled = false;
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
            digitButtons = calculDigits.GetComponentsInChildren<Button>();
            foreach (Button digitButton in digitButtons)
            {
                Debug.Log(digitButton + ": false");
                digitButton.enabled = true;
            }
            resultInput.SetActive(true);
            startText.gameObject.SetActive(false);
            this.enabled = false;
        }
    }

}