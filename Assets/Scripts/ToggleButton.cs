using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleButton : MonoBehaviour
{

    public bool ButtonOn = false;
    public Button MyButton;
    public string prefParam;
    public int defaultParam;

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

    void OnMouseOver()
    {
        Color newColor = new Color(0.7f, 0.7f, 0.7f, 1f);
        MyButton.image.color = newColor;
        Debug.Log("Mouse is OVER GameObject.");
    }

    void OnMouseExit()
    {
        //The mouse is no longer hovering over the GameObject so output this message each frame
        Debug.Log("Mouse is no longer on GameObject.");
    }


}