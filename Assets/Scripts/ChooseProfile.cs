using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseProfile : MonoBehaviour
{
    public TMP_Dropdown profileDrop;

    void dropDownUpdate()
    {
        ExistingProfiles existProfiles = ProfileManagement.LoadAllProfiles();
        if (existProfiles != null)
        {
            List<string> profileNames = new List<string>();
            //Debug.Log("EXIST "+existProfiles);
            foreach (ProfileData profile in existProfiles.profiles)
            {
                profileNames.Add(profile.name);
                //Debug.Log("Profile FOUND "+profile.name);
            }
            profileDrop.AddOptions(profileNames);
        }

    }

    void OnEnable()
    {
        dropDownUpdate();
    }

    public void selectProfile()
    {
        string name = profileDrop.options[profileDrop.value].text;
        CurrentProfile currentProfile = GameObject.Find("CurrentProfile").GetComponent<CurrentProfile>();
        currentProfile.profile = ProfileManagement.LoadProfile(name);

    }
}
