using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTablesGamePref : MonoBehaviour
{
    public void setDifficulty(int difficulty)
    {
        PlayerPrefs.SetInt("TablesDifficulty", difficulty);
    }

    public void setNumberTable(string param)
    {
        if (PlayerPrefs.GetInt(param+"Table", 0) == 0)
        {
            PlayerPrefs.SetInt(param+"Table", 1);
        }
        else
        {
            PlayerPrefs.SetInt(param+"Table", 0);
        }
    }


}
