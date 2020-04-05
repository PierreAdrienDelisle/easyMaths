using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NewRecord : MonoBehaviour
{
    public TMP_Text newRecordText;
    private ProfileData profile;

    public void Start()
    {
        profile = GameObject.Find("CurrentProfile").GetComponent<CurrentProfile>().profile;

    }

    public bool isCalculRecord(int score)
    {
        if(profile.calculBestScore < score)
        {
            ProfileManagement.UpdateProfile(profile.name, score, profile.tableBestScore);
            newRecordText.text = "Bravo " + profile.name + " ! Nouveau record !";
            return true;
        }
        return false;
    }

    public bool isTableRecord(int score)
    {
        Debug.Log(profile);
        Debug.Log(profile.tableBestScore);
        Debug.Log(score);
        if (profile.tableBestScore < score)
        {
            ProfileManagement.UpdateProfile(profile.name, profile.calculBestScore, score);
            newRecordText.text = "Bravo " + profile.name + " ! Nouveau record !";
            return true;
        }
        return false;
    }
}
