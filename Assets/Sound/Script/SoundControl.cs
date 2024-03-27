using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class SoundControl : MonoBehaviour
{
    public AudioMixer masterMixer;
    public Slider audioSlider;
    public Database theDB;

    private void Start()
    {
        theDB = FindObjectOfType<Database>();
    }



    private void Update()
    {
        if(this.gameObject.transform.tag == "BGMSlider")
        {
            audioSlider.value = theDB.bgmVolume;
        }
        if (this.gameObject.transform.tag == "SFXSlider")
        {
            audioSlider.value = theDB.sfxVolume;
        }
    }

    public void BGMControl()
    {
        theDB.bgmVolume = audioSlider.value;
        float sound = theDB.bgmVolume;

        if(sound == -40f)
        {
            masterMixer.SetFloat("BGM", -80);
        }
        else
        {
            masterMixer.SetFloat("BGM", sound);
        }
    }
    public void SFXControl()
    {
        theDB.sfxVolume = audioSlider.value;
        float sound = theDB.sfxVolume;

        if (sound == -40f)
        {
            masterMixer.SetFloat("SFX", -80);
        }
        else
        {
            masterMixer.SetFloat("SFX", sound);
        }
    }
}
