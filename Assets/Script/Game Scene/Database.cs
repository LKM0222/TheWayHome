using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Database : MonoBehaviour
{
    UIScript theUI;
    SkinDataBase theSkinDB;

    public float mapMovingSpeed;
    public float fixMapMovingSpeed = 2;

    public float playerUpSpeed;
    public float playerMaxSpeed;

    public float playerMaxEnergy;
    public float playerEnergy;
    public float playerRevivalEnergy;
    public float wormholeEnergy;
    public float playerConsumeEnergy;
    public float wallHitEnergy;
    public float downConsumeEnergy;
    public float dangerExitEnergy;

    public float playerAddedEnergy;
    public float playerAddedMaxEnergy;

    public float playerPlusScore;
    public float bigStarScore;
    public float smallStarScore;
    public float zodiacScore;

    public bool gameoverFlag = false;//게임종료가 되면 최고점수기록을 위해 만들어둔 플래그
    public float score;
    public float highScore; //보존 필

    public int playerMoney; 
    public int totalPlayerMoney; // 보존필
    public int item_spareFuel;
    public int item_addedFuel;
    public int item_shield;

    public bool mapInstantiateFlag = false;

    public Sprite[] meteorSprite;//유성의 스프라이트 담은 배열
    public float meteorTransTime = 0.5f;

    //Item Flag
    public bool spareFuel;//부활
    public bool addedFuel;//추가연료
    public bool shield; //방어막

    public int itemCode;

    //level var
    public int level;
    public float time = 0f;
    bool levelUpFlag = false;

    //warmholeCount
    public int wormholeCount;

    //Zodiac
    public bool ZodiacBoosterFlag;

    //BlackHoleFlag
    public bool blackHoleBoosterFlag = false;

    //sound
    [SerializeField] AudioSource theAudio;
    [SerializeField] float volume = 1f;

    //revival
    public bool revivalSoundFlag;
    [SerializeField] AudioClip revivalSound;

    //levelValueArray
    float[] mapSpeed = { 5f, 6f, 7f, 8f, 10f, 12f, 13f };//초기본
    //float[] mapSpeed = { 7f, 7.5f, 8f, 8.5f, 9f, 9.5f, 11f };//수정본

    public int[] wormHoleCountArr = { 4, 4, 5, 5, 7, 8, 9 };//초기본
    //public int[] wormHoleCountArr = { 4, 4, 5, 5, 7, 8, 9 };//수정본

    float[] playerSpeed = { 5f, 5.5f, 6f, 6.5f, 7f, 7.5f, 10f };//초기본
    //float[] playerSpeed = { 8f, 9f, 10f, 11f, 13f, 15f, 16f };//수정본


    //Skin
    public int skinNum;

    //Volume
    public float bgmVolume;
    public float sfxVolume;

    //ad
    public int adCount = 0;


    private void Awake()
    {
        var obj = FindObjectsOfType<Database>();

        if(obj.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        GameDataLoad();
    }

    // Start is called before the first frame update
    void Start()
    {
        theUI = FindObjectOfType<UIScript>();
        theSkinDB = FindObjectOfType<SkinDataBase>();
        Init();
    }

    
    private void Update()
    {
        if (SceneManager.GetActiveScene().name == "GameScene")
        {
            if(!addedFuel)
                playerEnergy -= Time.deltaTime * playerConsumeEnergy;

            score += Time.deltaTime * playerPlusScore;
            time += Time.deltaTime;
        }

        //highscore 기록을 위한 조건문
        if (gameoverFlag)
        {
            if (score > highScore)
            {
                highScore = score;
            }

        }

        if(playerEnergy > playerMaxEnergy)
        {
            playerEnergy = playerMaxEnergy;
        }

        //레벨 업 조건문
        if (time > 0f && time < 15f)
        {
            level = 1;
            mapMovingSpeed = mapSpeed[0];
            playerUpSpeed = playerSpeed[0];
        }
        else if (time > 15f && time < 30f)
        {
            level = 2;
            mapMovingSpeed = mapSpeed[1];
            playerUpSpeed = playerSpeed[1];
        }
        else if (time > 30f && time < 50f)
        {
            level = 3;
            mapMovingSpeed = mapSpeed[2];
            playerUpSpeed = playerSpeed[2];
        }
        else if (time > 50f && time < 75f)
        {
            level = 4;
            mapMovingSpeed = mapSpeed[3];
            playerUpSpeed = playerSpeed[3];
        }
        else if (time > 75f && time < 105f)
        {
            level = 5;
            mapMovingSpeed = mapSpeed[4];
            playerUpSpeed = playerSpeed[4];
        }
        else if (time > 105f && time < 140f)
        {
            level = 6;
            mapMovingSpeed = mapSpeed[5];
            playerUpSpeed = playerSpeed[5];
        }
        else
        {
            level = 7;
            mapMovingSpeed = mapSpeed[6];
            playerUpSpeed = playerSpeed[6];
        }

    }

    public void Init()
    {
        Time.timeScale = 1f;
        mapMovingSpeed = 2f;
        playerUpSpeed = 5f;
        time = 0f;
        score = 0f;

        totalPlayerMoney += playerMoney;
        playerMoney = 0;
        playerAddedEnergy = 300f;
        playerAddedMaxEnergy = 300f;

        playerConsumeEnergy = 30f;
        wormholeCount = 2;

        GameDataSave();
        GameDataLoad();
        

        if (addedFuel)
        {
            playerEnergy = 5300f + theSkinDB.CheckFlag() * 100; // 100씩 늘어나야됨 스킨 갯수마다
            playerMaxEnergy = 5300f + theSkinDB.CheckFlag() * 100;
        }
        else
        {
            playerEnergy = 5000f + theSkinDB.CheckFlag() * 100; // 100씩 늘어나야됨 스킨 갯수마다
            playerMaxEnergy = 5000f + theSkinDB.CheckFlag() * 100; // 100씩 늘어나야됨 스킨 갯수마다
        }
            

        gameoverFlag = false;
    }

    public void GameDataSave()
    {
        PlayerPrefs.SetFloat("HighScore", highScore);
        PlayerPrefs.SetInt("TotalMoney", totalPlayerMoney);
        PlayerPrefs.SetFloat("Volume", volume);
        PlayerPrefs.SetInt("SkinNum", skinNum);
        
        PlayerPrefs.Save();
    }

    void GameDataLoad()
    {
        highScore = PlayerPrefs.GetFloat("HighScore");
        totalPlayerMoney = PlayerPrefs.GetInt("TotalMoney");
        volume = PlayerPrefs.GetFloat("Volume");
        skinNum = PlayerPrefs.GetInt("SkinNum");
        
    }


    
}
