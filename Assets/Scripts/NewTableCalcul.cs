using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NCalc;
using System;
using TMPro;

public class NewTableCalcul : MonoBehaviour
{
    public TMP_Text calculText;
    public List<int> operations;
    public int difficulty;
    public int firstOp;
    public int secondOp;
    public string Number;
    public List<int> activeNumber;
    public int resultExpected;
    public string calculQuestion;
    private Expression exp;

    private string intToName(int number)
    {
        string name = "";
        switch (number)
        {
            case 0:
                name = "Zero";
                break;
            case 1:
                name = "One";
                break;
            case 2:
                name = "Two";
                break;
            case 3:
                name = "Three";
                break;
            case 4:
                name = "Four";
                break;
            case 5:
                name = "Five";
                break;
            case 6:
                name = "Six";
                break;
            case 7:
                name = "Seven";
                break;
            case 8:
                name = "Eight";
                break;
            case 9:
                name = "Nine";
                break;

        }
        return name;
    }
    // Start is called before the first frame update
    void Awake()
    {
        for(int i = 0; i < 10; i++)
        {
            int numberPref = PlayerPrefs.GetInt(intToName(i) + "Table", 0);
            if(numberPref == 1)
            {
                activeNumber.Add(i);
            }

        }
        difficulty = PlayerPrefs.GetInt("TablesDifficulty", 1);

    }

    public void randomCalcul()
    {
        firstOp = (int)activeNumber[UnityEngine.Random.Range(0, activeNumber.Count)];
        if (difficulty == 1)
        {
            secondOp = easyDiff();
        }
        else if (difficulty == 2)
        {
            secondOp = moderateDiff();

        }
        else
        {
            secondOp = hardDiff();
        }


        calculQuestion = firstOp.ToString() + "*" + secondOp.ToString();

        try // random errors due to runtime evaluation expression
        {
        
            Expression e = new Expression(calculQuestion);
            resultExpected = (int)e.Evaluate();
        }
        catch
        {
            randomCalcul();
            return;
        }
        calculQuestion = firstOp.ToString() + "x" + secondOp.ToString();
        calculText.text = calculQuestion;
    }

    private int easyDiff()
    {
        float rand = UnityEngine.Random.value;
        if (rand <= .1f)
        {
            return 0;
        }
        return UnityEngine.Random.Range(1, 6);

    }

    private int moderateDiff()
    {
        float rand = UnityEngine.Random.value;
        if (rand <= .5f)
        {
            return UnityEngine.Random.Range(0, 5);
        }
        else if (rand <= .8f)
        {
            return UnityEngine.Random.Range(5, 8);
        }
        return UnityEngine.Random.Range(8, 10);

    }

    private int hardDiff()
    {
        float rand = UnityEngine.Random.value;
        if (rand <= .3f)
        {
            return UnityEngine.Random.Range(0, 5);
        }
        else if (rand <= .5f)
        {
            return UnityEngine.Random.Range(5, 8);
        }
        else if (rand <= .8f)
        {
            return UnityEngine.Random.Range(8, 10);
        }
        return UnityEngine.Random.Range(10, 20);

    }
}
