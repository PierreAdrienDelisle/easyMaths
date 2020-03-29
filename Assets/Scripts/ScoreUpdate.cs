using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreUpdate : MonoBehaviour
{
    public int score = 0;
    public TMP_Text scoreText;

    public void correctAnswer()
    {
        score += 10;
    }

    public void wrongAnswer()
    {
        score -= 5;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
