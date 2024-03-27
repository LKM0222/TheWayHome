using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinDataBase : MonoBehaviour
{
    Database theDB;

    // num : 순서대로
    public int[] prise
     =
    {
        0,200,300,400,
        1000,2000,10000,4000,
        0,0,0,0
    };

    public bool[] buyFlag;// = new bool[12];
    
    public Sprite[] playerSprite;

    private void Awake()
    {
        var obj = FindObjectsOfType<Database>();

        if (obj.Length == 1)
        {
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public int clickNum;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
        SkinFlagGet();
        buyFlag[0] = true;
    }

    // Update is called once per frame
    void Update()
    {
        ScoreSkinFlag();
        
    }

    public void ScoreSkinFlag()
    {
        if (theDB.highScore >= prise[6])
        {
            buyFlag[6] = true;
        }
    }

    //playerprefs에 저장한건 db로딩시에만 가져오면 됨.
    //prlayerprefs은 아이템 살 때마다 초기화 시킴.
    public void SkinFlagSet(int num)
    {
        PlayerPrefs.SetInt("Skin" + num.ToString(), 1);
        PlayerPrefs.Save();

        for(int i = 0; i < buyFlag.Length; i++)
        {
            print(PlayerPrefs.GetInt("Skin" + num.ToString()));
        }
    }

    public void SkinFlagGet()
    {
        for (int i = 0; i < buyFlag.Length; i++)
        {
            if (PlayerPrefs.GetInt("Skin" + i.ToString()) == 1)
            {
                buyFlag[i] = true;
            }
            else
                buyFlag[i] = false;
                
        }
    }

    public int CheckFlag(){
        int i;
        int returnNum = 0;
        for(i = 0;i<buyFlag.Length;i++){
            if(buyFlag[i])
                returnNum++;
        }

        return returnNum;
    }
}
