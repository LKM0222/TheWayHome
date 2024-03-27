using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioScript : MonoBehaviour
{
    AudioSource theAudio;

    [SerializeField] AudioClip[] audioclip;

    // Start is called before the first frame update
    void Start()
    {
        theAudio = this.GetComponent<AudioSource>();
        StartCoroutine("SoundStartCoroutine");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SoundStartCoroutine()
    {
        //print("coroutine");
        theAudio.clip = audioclip[0];
        theAudio.Play();
        while (true)
        {
            yield return new WaitForSeconds(0.01f);
            if(!theAudio.isPlaying)
            {
                theAudio.clip = audioclip[1];
                theAudio.Play();
                theAudio.loop = true;
            }
        }
    }
}
