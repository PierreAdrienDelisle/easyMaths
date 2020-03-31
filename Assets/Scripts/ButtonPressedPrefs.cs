using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ButtonPressedPrefs : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;

    public Button plusButton;
    public Button minusButton;
    public Button multiplyButton;
    public Button divideButton;

    private int levelPref;
    
    private void Update()
    {
        levelPref = PlayerPrefs.GetInt("CalculDifficulty",1);
        if(levelPref == 1)
        {
            level1.GetComponent<ToggleButton>().ActivateButton();
            level2.GetComponent<ToggleButton>().DeactivateButton();
            level3.GetComponent<ToggleButton>().DeactivateButton();
        }
        else if(levelPref == 2)
        {
            level2.GetComponent<ToggleButton>().ActivateButton();
            level1.GetComponent<ToggleButton>().DeactivateButton();
            level3.GetComponent<ToggleButton>().DeactivateButton();
        }
        else if(levelPref == 3)
        {
            level3.GetComponent<ToggleButton>().ActivateButton();
            level2.GetComponent<ToggleButton>().DeactivateButton();
            level1.GetComponent<ToggleButton>().DeactivateButton();
        }
        int plusPref= PlayerPrefs.GetInt("PlusOp", 1);
        int minusPref = PlayerPrefs.GetInt("MinusOp", 0);
        int multiplyPref = PlayerPrefs.GetInt("MultiplyOp", 0);
        int dividePref = PlayerPrefs.GetInt("DivideOp", 0);
        if (plusPref == 1) { plusButton.GetComponent<ToggleButton>().ActivateButton(); } else { plusButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (minusPref == 1) { minusButton.GetComponent<ToggleButton>().ActivateButton(); } else { minusButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (multiplyPref == 1) { multiplyButton.GetComponent<ToggleButton>().ActivateButton(); } else { multiplyButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (dividePref == 1) { divideButton.GetComponent<ToggleButton>().ActivateButton(); } else { divideButton.GetComponent<ToggleButton>().DeactivateButton(); }



    }
}