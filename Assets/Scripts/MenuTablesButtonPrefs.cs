using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuTablesButtonPrefs : MonoBehaviour
{
    public Button level1;
    public Button level2;
    public Button level3;

    public Button oneButton;
    public Button twoButton;
    public Button threeButton;
    public Button fourButton;
    public Button fiveButton;
    public Button sixButton;
    public Button sevenButton;
    public Button eightButton;
    public Button nineButton;
    public Button zeroButton;

    private int levelPref;
    private void Start()
    {
        
    }
    private void Update()
    {
        levelPref = PlayerPrefs.GetInt("TablesDifficulty", 1);
        if (levelPref == 1)
        {
            level1.GetComponent<ToggleButton>().ActivateButton();
            level2.GetComponent<ToggleButton>().DeactivateButton();
            level3.GetComponent<ToggleButton>().DeactivateButton();
        }
        else if (levelPref == 2)
        {
            level2.GetComponent<ToggleButton>().ActivateButton();
            level1.GetComponent<ToggleButton>().DeactivateButton();
            level3.GetComponent<ToggleButton>().DeactivateButton();
        }
        else if (levelPref == 3)
        {
            level3.GetComponent<ToggleButton>().ActivateButton();
            level2.GetComponent<ToggleButton>().DeactivateButton();
            level1.GetComponent<ToggleButton>().DeactivateButton();
        }

        if (PlayerPrefs.GetInt("OneTable") == 1) { oneButton.GetComponent<ToggleButton>().ActivateButton(); } else { oneButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("TwoTable") == 1) { twoButton.GetComponent<ToggleButton>().ActivateButton(); } else { twoButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("ThreeTable") == 1) { threeButton.GetComponent<ToggleButton>().ActivateButton(); } else { threeButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("FourTable") == 1) { fourButton.GetComponent<ToggleButton>().ActivateButton(); } else { fourButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("FiveTable") == 1) { fiveButton.GetComponent<ToggleButton>().ActivateButton(); } else { fiveButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("SixTable") == 1) { sixButton.GetComponent<ToggleButton>().ActivateButton(); } else { sixButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("SevenTable") == 1) { sevenButton.GetComponent<ToggleButton>().ActivateButton(); } else { sevenButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("EightTable") == 1) { eightButton.GetComponent<ToggleButton>().ActivateButton(); } else { eightButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("NineTable") == 1) { nineButton.GetComponent<ToggleButton>().ActivateButton(); } else { nineButton.GetComponent<ToggleButton>().DeactivateButton(); }
        if (PlayerPrefs.GetInt("ZeroTable") == 1) { zeroButton.GetComponent<ToggleButton>().ActivateButton(); } else { zeroButton.GetComponent<ToggleButton>().DeactivateButton(); }

    }
}
