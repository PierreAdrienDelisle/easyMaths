﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreUpdate : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + score.ToString();
    }
}
