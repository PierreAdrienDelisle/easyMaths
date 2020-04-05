using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentProfile : MonoBehaviour
{

    public static CurrentProfile currentProfile;
    public ProfileData profile;
    public string name;

    void Awake()
    {
        if (currentProfile == null)
        {
            DontDestroyOnLoad(gameObject);
            currentProfile = this;
        }else if(currentProfile != this)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
       if(profile != null)
        {
            name = profile.name;
        } 
    }
}
