using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    Database theDB;

    [SerializeField] Text scoreText;
    [SerializeField] Text highScoreText;

    public Slider playerEnergySlider;
    public Slider playerAddedEnergySlider;
    public GameObject playerAddedEnergySliderImg;

    public Text gameOverScore;
    public Text gameOverIncome;

    public GameObject shieldImg;
    public GameObject revivalImg;

    [SerializeField] GameObject wing;
    [SerializeField] GameObject lightning;

    //[SerializeField] Image shield;
    [SerializeField] Image revival;

    PlayerMovingButton thePlayer;

    //audio
    AudioSource theAudio;
    [SerializeField] AudioClip boosterSound,revivalSound;
    bool revivalSoundFlag = false;

    //0번째 이미지는 안쓰는 이미지
    ZodiacSoundController theZodiacSoundController;
    [SerializeField] GameObject[] zodiacImg;
    [SerializeField] Image[] zodiac;
    public bool[] zodiacFlag = {true ,false, false, false, false, false, false, false, false, false, false, false, false };
    public int zodiacNum;
    public Slider zodiacSlider;
    public bool zodiacCheckStartFlag = true;
    public bool zodiacBoosterSoundFlag = false;



    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
        thePlayer = FindObjectOfType<PlayerMovingButton>();
        theAudio = GetComponent<AudioSource>();
        theZodiacSoundController = FindObjectOfType<ZodiacSoundController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = string.Format("{0:#,0}", Mathf.Round(theDB.score)); 
        highScoreText.text = string.Format("{0:#,0}", Mathf.Round(theDB.highScore));

        gameOverScore.text = Mathf.Round(theDB.score).ToString();
        gameOverIncome.text = string.Format("{0:#,0}", Mathf.Round(theDB.playerMoney));

        if (theDB.addedFuel)
        {
            playerAddedEnergySliderImg.SetActive(true);
            playerAddedEnergySlider.maxValue = theDB.playerAddedMaxEnergy;
            playerAddedEnergySlider.value = theDB.playerAddedEnergy;

            theDB.playerAddedEnergy -= Time.deltaTime * theDB.playerConsumeEnergy;

            if (theDB.playerAddedEnergy <= 0f)
                theDB.addedFuel = false;

        }
        else
        {
            playerAddedEnergySliderImg.SetActive(false);
            playerAddedEnergySlider.value = 0f;
        }



        if (!theDB.addedFuel)
        {
            playerEnergySlider.value = theDB.playerEnergy;
            playerEnergySlider.maxValue = theDB.playerMaxEnergy;
        }


        if (theDB.spareFuel)
        {
            wing.SetActive(true);
            lightning.SetActive(false);
        }
        else
        {
            if (theDB.revivalSoundFlag)
            {
                StartCoroutine(RevivalSound());
            }
            wing.SetActive(false);
            lightning.SetActive(true);
        }


        //zodiac img
        zodiacImg[zodiacNum].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 1f);
        zodiac[zodiacNum].color = new Color(1f, 1f, 1f, 1f);
        zodiacFlag[zodiacNum] = true;
        if (zodiacCheckStartFlag)
        {
            ZodiacCheckFlag();
            
        }
    }

    public void ZodiacFalse()
    {
        zodiacNum = 0;
        for (int i = 1; i <= 12; i++)
        {
            zodiacFlag[i] = false;
            //zodiacImg[i].GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 1f, 0.3f);
            
            zodiac[i].color = new Color(1f, 1f, 1f, 0.3f);
        }
        
    }

    public void ZodiacCheckFlag()
    {
        if(zodiacFlag[12] && zodiacFlag[1] && zodiacFlag[2] && zodiacFlag[3] &&
            zodiacFlag[4] && zodiacFlag[5] && zodiacFlag[6] && zodiacFlag[7] &&
            zodiacFlag[8] && zodiacFlag[9] && zodiacFlag[10] && zodiacFlag[11] )
        {

            zodiacBoosterSoundFlag = true;
            theZodiacSoundController.loopFlag = true;

            //플레이어 스킨에 따라서 이미지 변
            theDB.ZodiacBoosterFlag = true;
            zodiacSlider.value = 20f;
            zodiacCheckStartFlag = false;
            thePlayer.PlayerLayerSet(1);

           
        }
    }

    IEnumerator RevivalSound()
    {
        for(int i = 0; i < 1; i++)
        {
            print("Coroutine Play");
            theAudio.clip = revivalSound;
            theAudio.Play();
            theDB.revivalSoundFlag = false;
            yield return new WaitForSeconds(0.1f);
        }
    }

    
}


