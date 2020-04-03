using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class timerSettings : MonoBehaviour
{
    public TMP_Dropdown timerDropdown;


    private int timerCase()
    {
        switch (PlayerPrefs.GetInt("timer", 30))
        {
            case 30:
                return 0;
            case 60:
                return 1;
            case 90:
                return 2;
            case 180:
                return 3;
            case 300:
                return 4;
            case 600:
                return 5;
            case 900:
                return 6;
        }
        return 0;
    }

    private int valueTimer(int value)
    {
        switch (value)
        {
            case 0:
                return 30;
            case 1:
                return 60;
            case 2:
                return 90;
            case 3:
                return 180;
            case 4:
                return 300;
            case 5:
                return 600;
            case 6:
                return 900;
        }
        return 0;
    }
    // Start is called before the first frame update
    void Start()
    {
        timerDropdown.value = timerCase();
    }
    public void setTimerPref()
    {
        int newTimer = valueTimer(timerDropdown.value);
        Debug.Log(newTimer);
        PlayerPrefs.SetInt("timer", newTimer);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
