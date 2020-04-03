using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using NCalc;
using System;

public class NewCalcul : MonoBehaviour
{
    public TMP_Text calculText;
    public List<int> operations;
    public int difficulty;
    public int firstOp;
    public int secondOp;
    public string Operator;
    public List<string> activeOp;
    public int resultExpected;
    public string calculQuestion;
    private Expression exp;

    // Start is called before the first frame update
    void Awake()
    {
        operations.Add(PlayerPrefs.GetInt("PlusOp", 1));
        operations.Add(PlayerPrefs.GetInt("MinusOp", 0));
        operations.Add(PlayerPrefs.GetInt("MultiplyOp", 0));
        operations.Add(PlayerPrefs.GetInt("DivideOp", 0));
        if ((int)operations[0] == 1)
        {
            activeOp.Add("+");
        }
        if ((int)operations[1] == 1)
        {
            activeOp.Add("-");
        }
        if ((int)operations[2] == 1)
        {
            activeOp.Add("*");
        }
        if (operations[3] == 1)
        {
            activeOp.Add("/");
        }
        difficulty = PlayerPrefs.GetInt("CalculDifficulty", 1);
        
    }

    public void randomCalcul()
    {
        Operator = (string)activeOp[UnityEngine.Random.Range(0, activeOp.Count)];
        if (difficulty == 1)
        {
            firstOp = easyDiff();
            secondOp = easyDiff();
        }
        else if(difficulty == 2)
        {
            firstOp = moderateDiff();
            secondOp = moderateDiff();
            
        }
        else
        {
            firstOp = hardDiff();
            secondOp = hardDiff();
        }

        if(firstOp < secondOp && (Operator == "/" || Operator == "-")) // Change order to avoid negative values or 0 divide values
        {
            int temp = secondOp;
            secondOp = firstOp;
            firstOp = temp;
        }

        calculQuestion = firstOp.ToString() + Operator + secondOp.ToString();
        if ((Operator == "/") && secondOp == 0) // not divide by zero
        {
            Debug.Log("NEW random calcul");
            randomCalcul();
            return;
        }

        try // random errors due to runtime evaluation expression
        {
            Debug.Log("EXP");
            Expression e = new Expression(calculQuestion);
            if (Operator == "/") // convert double to int
            {
                resultExpected = Convert.ToInt32(Math.Floor((double)e.Evaluate()));
            }
            else
            {
                Debug.Log(calculQuestion);
                Debug.Log(e.Evaluate());
                resultExpected = (int)e.Evaluate();
            }
        }
        catch
        {
            randomCalcul();
            return;
        }

        if (Operator == "*") // Change display for * to x
        {
            calculQuestion = firstOp.ToString() + "x" + secondOp.ToString();
        }

        calculText.text = calculQuestion;
    }

    private int easyDiff()
    {
        float rand = UnityEngine.Random.value;
        if (rand <= .1f){
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
        }else if (rand <= .8f)
        {
            return UnityEngine.Random.Range(8, 10);
        }
        return UnityEngine.Random.Range(10, 20);

    }

}
