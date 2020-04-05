using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{

    public bool ButtonOn = false;
    public Button MyButton;
    public string prefParam;

    public void Awake()
    {
       int param = PlayerPrefs.GetInt(prefParam, 1);
        if(param == 1)
        {
            ButtonOn = true;
            MyButton.image.color = Color.white;
        }
        else
        {
            ButtonOn = false;
            MyButton.image.color = Color.grey;
        }

    }
    public void BeenClicked()
    {

        ButtonOn = !ButtonOn;
        if (ButtonOn)
        {
            MyButton.image.color = Color.white;
        }
        else
        {
            MyButton.image.color = Color.grey;
        }
    }

    public void DeactivateButton()
    {
        ButtonOn = false;
        MyButton.image.color = Color.grey;
    }

    public void ActivateButton()
    {
        ButtonOn = true;
        MyButton.image.color = Color.white;
    }




}