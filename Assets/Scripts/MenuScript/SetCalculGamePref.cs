using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCalculGamePref : MonoBehaviour
{
    public void setDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("CalculDifficulty", difficulty);
    }

    public void setPlusOp()
    {
        if (PlayerPrefs.GetInt("PlusOp", 0) == 0){
            PlayerPrefs.SetInt("PlusOp", 1);
        }else{
            PlayerPrefs.SetInt("PlusOp", 0);
        }
    }
    public void setMinusOp()
    {
        if (PlayerPrefs.GetInt("MinusOp", 0) == 0){
            PlayerPrefs.SetInt("MinusOp", 1);
        }else{
            PlayerPrefs.SetInt("MinusOp", 0);
        }
    }

    public void setMultiplyOp()
    {
        if(PlayerPrefs.GetInt("MultiplyOp",0) == 0) {
            PlayerPrefs.SetInt("MultiplyOp", 1);
        }else{
            PlayerPrefs.SetInt("MultiplyOp", 0);
        }

    }
    public void setDivideOp()
    {
        if (PlayerPrefs.GetInt("DivideOp", 0) == 0){
            PlayerPrefs.SetInt("DivideOp", 1);
        }else{
            PlayerPrefs.SetInt("DivideOp", 0);
        }
    }

}
