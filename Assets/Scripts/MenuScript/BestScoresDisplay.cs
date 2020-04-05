using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScoresDisplay : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text bestCalculText;
    public TMP_Text bestTableText;


    public void Update()
    {
        ProfileData profile = GameObject.Find("CurrentProfile").GetComponent<CurrentProfile>().profile;
        nameText.text = profile.name;
        bestCalculText.text = "Calcul : "+profile.calculBestScore.ToString();
        bestTableText.text = "Tables : "+profile.tableBestScore.ToString();

    }
}
