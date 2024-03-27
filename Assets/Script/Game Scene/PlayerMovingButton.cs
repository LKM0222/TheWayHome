using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovingButton : MonoBehaviour
{
    [SerializeField] GameObject thePlayer;
    [SerializeField] GameObject shieldImg;
    [SerializeField] GameObject boosterImg;

    Database theDB;
    Animator theAnimator;

    //public GameObject dangerImg;
    public Image dangerImg;
    
    Coroutine dangerCoroutine;

    //blackHole
    bool blackHoleFlag = true;
    float whiteHoleYPos;
    float BlackHoleYPos;
    public GameObject blackHall;

    //zodiac
    UIScript theUI;

    //Audio
    AudioSource theAudio;
    [SerializeField] AudioClip hitSound, itemSound, blackHoleSound, wormHoleSound, shieldSound, dangerSound;

    //Skin
    SkinDataBase theSkinDB;


    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
        theUI = FindObjectOfType<UIScript>();
        theAnimator = GetComponent<Animator>();
        theAudio = GetComponent<AudioSource>();
        theSkinDB = FindObjectOfType<SkinDataBase>();
        theAnimator.Play("GameSceneStart");
    }

    // Update is called once per frame
    void Update()
    {
        if (theDB.shield)
        {
            shieldImg.GetComponent<Animator>().SetBool("IsDestroy", false);
        }
        else
        {
            shieldImg.GetComponent<Animator>().SetBool("IsDestroy", true);
        }

        if (blackHoleFlag)//블랙홀을 먹지 않았다면 일반적으로 움직인다.
        {
            //touch event
            if (Input.GetMouseButton(0))
            {
                thePlayer.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * theDB.playerUpSpeed);
            }
            else
            {
                thePlayer.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime * theDB.playerUpSpeed);
            }
        }
        else //블랙홀을 먹었다면 다음과 같이 움직인다.
        {
            this.transform.position = Vector3.MoveTowards(this.transform.position,
                new Vector3(this.transform.position.x, whiteHoleYPos, this.transform.position.z),
                Time.deltaTime * 2f *theDB.playerUpSpeed);//* theDB.playerUpSpeed
        }


        this.transform.position = new Vector3(-6.5f, this.transform.position.y, this.transform.position.z);
        this.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);




        if (theDB.time > 1.2f)
            theAnimator.enabled = false;

        //don't move to camera bounds
        //카메라 밖으로 나가려고 할 때 플레이어의 크기의 반 만큼 나가게 됨 이거 수정 필요하면 수정하기.
        Vector3 pos = Camera.main.WorldToViewportPoint(transform.position);
        if (pos.x < 0f) pos.x = 0f;
        if (pos.x > 1f) pos.x = 1f;
        if (pos.y < -0.1f) pos.y = -0.1f;
        if (pos.y > 0.8f) pos.y = 0.8f; 
        transform.position = Camera.main.ViewportToWorldPoint(pos);

        if (theDB.ZodiacBoosterFlag)
        {
            if(this.GetComponent<SpriteRenderer>().sprite.name == "Heart"){
                print("Heart!");
                boosterImg.GetComponent<Animator>().SetBool("HeartBooster", true);
            }
            else
            boosterImg.GetComponent<Animator>().SetBool("BoosterFlag", true);
        }
        else
        {
            if(this.GetComponent<SpriteRenderer>().sprite.name == "Heart"){
                print("Heart!");
                boosterImg.GetComponent<Animator>().SetBool("HeartBooster", false);
            }
            boosterImg.GetComponent<Animator>().SetBool("BoosterFlag", false);
        }


        //player Skin
        this.GetComponent<SpriteRenderer>().sprite = theSkinDB.playerSprite[theDB.skinNum];

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            if (theDB.shield)
            {
                theAudio.clip = shieldSound;
                theAudio.Play();
                theDB.shield = false;
                PowerOverWhelming();
            }
            else
            {
                theDB.playerEnergy -= theDB.wallHitEnergy;
                theAudio.clip = hitSound;
                theAudio.Play();
                PowerOverWhelming();
            }

        }

        if (collision.gameObject.tag == "Warmhole")
        {
            theDB.playerEnergy += theDB.wormholeEnergy;
            theAudio.clip = wormHoleSound;
            theAudio.Play();
            print(theDB.playerEnergy);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "Blackhole")
        {
            theAudio.clip = blackHoleSound;
            theAudio.Play();
            this.gameObject.layer = 7;
            blackHoleFlag = false;
            theDB.blackHoleBoosterFlag = true;
            print(collision.transform.position.y);
            this.transform.position = new Vector3(this.transform.position.x,
                collision.transform.position.y, this.transform.position.z);

            BlackHoleYPos = collision.transform.position.y;
            whiteHoleYPos = collision.GetComponent<BlackHoleScript>().whiteHole.transform.position.y;

            print(BlackHoleYPos - whiteHoleYPos +", "+ whiteHoleYPos);
        }

        

        if (collision.gameObject.tag == "DangerZone")
        {
            //dangerImg.SetActive(true);
            theAudio.clip = dangerSound;
            theAudio.loop = true;
            theAudio.Play();
            dangerImg.GetComponent<Image>().color = new Color(dangerImg.color.r,
                dangerImg.color.g,
                dangerImg.color.b,
                0.2f);
            print("hit");
            dangerCoroutine = StartCoroutine(DangerImgPlay());
            theDB.playerConsumeEnergy = theDB.downConsumeEnergy;
        }
        
        if (collision.gameObject.tag == "Money5")
        {
            theDB.playerMoney += 5;
            Destroy(collision.gameObject);
            theAudio.clip = itemSound;
            theAudio.Play();
            print("money5");            
        }

        if (collision.gameObject.tag == "Money15")
        {
            theDB.playerMoney += 10;
            Destroy(collision.gameObject);
            theAudio.clip = itemSound;
            theAudio.Play();
            print("moeny15");
        }

        if(collision.tag == "Zodiac1")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 1;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac2")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 2;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac3")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 3;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac4")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 4;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac5")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 5;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac6")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 6;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac7")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 7;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac8")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 8;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac9")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 9;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac10")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 10;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac11")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 11;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if (collision.tag == "Zodiac12")
        {
            theDB.score += theDB.zodiacScore;
            theUI.zodiacNum = 12;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }


        if(collision.tag == "BigStar")
        {
            theDB.score += theDB.bigStarScore;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }
        if(collision.tag == "SmallStar")
        {
            theDB.score += theDB.smallStarScore;
            theAudio.clip = itemSound;
            theAudio.Play();
            Destroy(collision.gameObject);
        }

    }

    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DangerZone")
        {
            theAudio.Stop();
            theAudio.loop = false;
            dangerImg.color = new Color(dangerImg.color.r,
                dangerImg.color.g,
                dangerImg.color.b,
                0f);
            if(dangerCoroutine != null)
            {
                StopCoroutine(dangerCoroutine);
            }
            
            print("dangerZone Out");

            theDB.playerConsumeEnergy = theDB.dangerExitEnergy;
        }

        if (collision.gameObject.tag == "Whitehole")
        {
            print("out");
            //this.GetComponent<CapsuleCollider2D>().isTrigger = false;
            this.gameObject.layer = 6;
            theDB.blackHoleBoosterFlag = false;
            blackHoleFlag = true;

        }
    }


    public void PowerOverWhelming()
    {
        PlayerLayerSet(1);
        StartCoroutine(PlayerHit());
    }

    IEnumerator PlayerHit()
    {
        Color sprColor = this.GetComponent<SpriteRenderer>().color;

        for (int i = 0; i < 4; i++)
        {
            if (i % 2 == 0)
                sprColor.a = 0.5f;
            else
                sprColor.a = 1f;

            this.GetComponent<SpriteRenderer>().color = sprColor;
            yield return new WaitForSeconds(0.3f);
        }

        PlayerLayerSet(2);
        theDB.shield = false;

    }

    IEnumerator DangerImgPlay()
    {

        Color sprColor = dangerImg.color;

        for (int i = 0; ; i++)
        {
            if (i % 2 == 0)
                sprColor.a = 0.2f;
            else
                sprColor.a = 0f;

            dangerImg.color = sprColor;
            print("start Coroutine");
            yield return new WaitForSeconds(1f);
        }

    }

    public void PlayerLayerSet(int num)//1 : invincibility 2: no
    {
        if (num == 0)//zodiac
            this.gameObject.layer = 10;

        if (num == 1) //no hit
            this.gameObject.layer = 7;

        if(num == 2)//can hit
        {
            this.gameObject.layer = 6;
        }
    }
    

}
