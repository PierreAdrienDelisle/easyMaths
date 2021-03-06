﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ChooseProfile : MonoBehaviour
{
    public TMP_Dropdown profileDrop;
    public GameObject profileMenu;
    public GameObject GameModeMenu;
    public TMP_Text errorMessage;

    void dropDownUpdate()
    {
        ExistingProfiles existProfiles = ProfileManagement.LoadAllProfiles();
        profileDrop.options.Clear();
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
        try
        {
            string name = profileDrop.options[profileDrop.value].text;
            CurrentProfile currentProfile = GameObject.Find("CurrentProfile").GetComponent<CurrentProfile>();
            currentProfile.profile = ProfileManagement.LoadProfile(name);
            profileMenu.SetActive(false);
            GameModeMenu.SetActive(true);
        }
        catch
        {
            StartCoroutine(EmptyName(5.0f));
        }
    }

    public void deleteProfile()
    {
        string name = profileDrop.options[profileDrop.value].text;
        CurrentProfile currentProfile = GameObject.Find("CurrentProfile").GetComponent<CurrentProfile>();
        ProfileManagement.RemoveProfile(name);
        dropDownUpdate();
    }

    IEnumerator EmptyName(float time)
    {
        errorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        errorMessage.gameObject.SetActive(false);
    }
}
