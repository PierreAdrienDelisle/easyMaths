using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumePref : MonoBehaviour
{
    public AudioMixer mixer;
    public float volumePref;

    void Start()
    {
        volumePref = PlayerPrefs.GetFloat("MusicVolume", 0.25f);
        mixer.SetFloat("MusicVol", Mathf.Log10(volumePref)*20);
    }

}
