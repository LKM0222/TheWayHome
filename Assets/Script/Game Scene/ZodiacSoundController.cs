using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZodiacSoundController : MonoBehaviour
{
    [SerializeField] AudioSource ingameBGM;
    AudioSource zodiacBGM;
    UIScript theUI;

    public bool loopFlag = false;

    // Start is called before the first frame update
    void Start()
    {
        zodiacBGM = this.GetComponent<AudioSource>();
        theUI = FindObjectOfType<UIScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (loopFlag)
        {
            if (theUI.zodiacBoosterSoundFlag)
            {
                
                ingameBGM.mute = true;
                zodiacBGM.Play();
                loopFlag = false;
            }
        }
        if (theUI.zodiacSlider.value <= 0f)
        {
            zodiacBGM.Stop();
            theUI.zodiacBoosterSoundFlag = false;
            ingameBGM.mute = false;
        }

    }
}
