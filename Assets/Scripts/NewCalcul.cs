using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEditor;

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
        Operator = (string)activeOp[Random.Range(0, activeOp.Count)];
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
            firstOp = Random.Range(0, 100);
            secondOp = Random.Range(0, 100);
        }

        if(firstOp < secondOp && (Operator == "/" || Operator == "-"))
        {
            int temp = secondOp;
            secondOp = firstOp;
            firstOp = temp;
        }

        calculQuestion = firstOp.ToString() + Operator + secondOp.ToString();
        calculText.text = calculQuestion;
        if ((Operator == "/") && secondOp == 0)
        {
            randomCalcul();
        }
        ExpressionEvaluator.Evaluate<int>(calculText.text,out resultExpected);
    }

    private int easyDiff()
    {
        float rand = Random.value;
        if (rand <= .5f){
            return Random.Range(0, 5);
        }else if (rand <= .8f){
            return Random.Range(5, 8);
        }
        return Random.Range(8, 10);
        
    }

    private int moderateDiff()
    {
        float rand = Random.value;
        if (rand <= .3f)
        {
            return Random.Range(0, 5);
        }
        else if (rand <= .5f)
        {
            return Random.Range(5, 8);
        }else if (rand <= .8f)
        {
            return Random.Range(8, 10);
        }
        return Random.Range(10, 15);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
