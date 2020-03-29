using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DigitScript : MonoBehaviour
{
    public int buttonValue;
    public TMP_InputField resultInput;

    public void addDigitValue()
    {
        resultInput.text += buttonValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
