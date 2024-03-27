using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapMoving : MonoBehaviour
{
    Database theDB;
    SpriteRenderer spr;
    MapSpawnScript theMapSpawnner;
    UIScript theUI;
    PlayerMovingButton thePlayer;

    [SerializeField] GameObject wormhole;

    public bool instantiateFlag = false;


    float speed;

    // Start is called before the first frame update
    void Start()
    {
        //씬의 시작때 맵의 위치를 고정 한 후 시작 맵의 위치를 변경시켜야 함.
        //모든 맵의 크기가 같다면 ???
        theDB = FindObjectOfType<Database>();
        spr = GetComponent<SpriteRenderer>();
        theUI = FindObjectOfType<UIScript>();
        thePlayer = FindObjectOfType<PlayerMovingButton>();
        theMapSpawnner = FindObjectOfType<MapSpawnScript>();

        //wormhole 생성 코드

        if (theDB.wormholeCount % theDB.wormHoleCountArr[theDB.level - 1] == 0)
        {
            print(theDB.wormholeCount + " " + theDB.wormHoleCountArr[theDB.level - 1]);
            wormhole.SetActive(true);
            theDB.wormholeCount = 1;
        }
        else
            wormhole.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        speed = theDB.mapMovingSpeed;

        if (theDB.blackHoleBoosterFlag)
        {
            speed = theDB.mapMovingSpeed * 2;
        }

        if (theDB.ZodiacBoosterFlag)
        {
            speed = theDB.mapMovingSpeed * 3;
            theDB.playerConsumeEnergy = 0f;
            theDB.playerPlusScore = 50f;
            thePlayer.PlayerLayerSet(0);
            theUI.ZodiacFalse();
            
            theUI.zodiacSlider.value -= 0.02f; // init 20;

            theUI.zodiacBoosterSoundFlag = true;

            if(theUI.zodiacSlider.value <= 0f)
            {
                theDB.ZodiacBoosterFlag = false;
                print("booster end");
                theDB.playerConsumeEnergy = 20f;
                theDB.playerPlusScore = 25f;
                thePlayer.PowerOverWhelming();
                thePlayer.PlayerLayerSet(2);
                theUI.zodiacSlider.value = 0f;
                theUI.zodiacCheckStartFlag = true;
                
            }
        }



        this.transform.Translate(new Vector3(-1, 0, 0) * Time.deltaTime * speed);


        var height = 2 * Camera.main.orthographicSize;
        var weigh = height * Camera.main.aspect; //스크린의 가로 크기를 구함.

        //스프라이트의 가로 크기에서 자신의 현재 위치한 값을 더했을때 스크린의 가로 크기보다 작다면
        //즉 스프라이트가 화면의 끝에 도달했다면
        //스프라이트를 다음 따라오는 스프라이트 옆에 붙인다. 무한맵 생성
        Vector3 pos = transform.position;
        if(pos.x + spr.bounds.size.x / 10 < -weigh)// spr.bounds.size.x / 2를 수정함
        {
            theDB.mapInstantiateFlag = true;
            Destroy(this.gameObject);
        }

    }
}
