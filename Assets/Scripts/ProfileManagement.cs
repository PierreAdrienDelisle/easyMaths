using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class ProfileManagement : MonoBehaviour
{
    public TMP_InputField profileInput;
    public TMP_Dropdown profileDropdown;
    public TMP_Text errorMessage;
    public GameObject createProfileMenu;
    public GameObject profileMenu;
    public static string pathProfile;


    private void Awake()
    {
        pathProfile = Application.persistentDataPath + "/profileInfo.json";
    }

    public void addNewProfile()
    {
        if (profileInput.text == "")
        {
            StartCoroutine(EmptyName(3.0f));
        }
        else
        {
            Debug.Log("SAVING PROFILE "+ profileInput.text);
            SaveProfile(profileInput.text, 0, 0);
            profileMenu.SetActive(true);
            createProfileMenu.SetActive(false);
        }
    }

    IEnumerator EmptyName(float time)
    {
        errorMessage.gameObject.SetActive(true);
        yield return new WaitForSeconds(time);
        errorMessage.gameObject.SetActive(false);
    }

    static public void SaveProfile(string name, int calculBestScore, int tableBestScore)
    {
        // open existing profiles
        ExistingProfiles existProfiles = new ExistingProfiles();
        if (File.Exists(pathProfile))
        {
            string jsonFile = System.IO.File.ReadAllText(pathProfile);
            existProfiles = JsonUtility.FromJson<ExistingProfiles>(jsonFile);
        }
        else
        {
            File.Create(pathProfile).Close();
            existProfiles = new ExistingProfiles();
            existProfiles.lastID = 0;
            existProfiles.profiles = new List<ProfileData>();
        }

        // new profile data
        ProfileData data = new ProfileData();
        existProfiles.lastID += 1;
        data.id = existProfiles.lastID;
        data.name = name;
        data.calculBestScore = calculBestScore;
        data.tableBestScore = tableBestScore;

        //add profile
        existProfiles.profiles.Add(data);
        string json = JsonUtility.ToJson(existProfiles);
        File.WriteAllText(pathProfile, json);
        existProfiles = JsonUtility.FromJson<ExistingProfiles>(json);

    }

    static public ProfileData LoadProfile(string name)
    {
        ProfileData myProfile = null;
        if (File.Exists(pathProfile)) // file exists
        {
            string jsonFile = System.IO.File.ReadAllText(pathProfile);
            ExistingProfiles existProfiles = JsonUtility.FromJson<ExistingProfiles>(jsonFile);
            foreach (ProfileData profileData in existProfiles.profiles) // find matching profile
            {
                if(profileData.name == name)
                {
                    myProfile = profileData;
                }
            }
        }
        Debug.Log("Profile LOADED ! " + myProfile.name + " id: " + myProfile.id + " bestScoreCalcul: " + myProfile.calculBestScore);
        return myProfile;
    }


    static public ExistingProfiles LoadAllProfiles()
    {
        pathProfile = Application.persistentDataPath + "/profileInfo.json";
        ExistingProfiles existProfiles = null;
        if (File.Exists(pathProfile)) // file exists
        {
            string jsonFile = System.IO.File.ReadAllText(pathProfile);
            existProfiles = JsonUtility.FromJson<ExistingProfiles>(jsonFile);
        }
        return existProfiles;
    }
}

[Serializable]
public class ExistingProfiles
{
    public List<ProfileData> profiles;
    public int lastID;
}

[Serializable]
public class ProfileData
{
    public int id;
    public string name;
    public int calculBestScore;
    public int tableBestScore;
}