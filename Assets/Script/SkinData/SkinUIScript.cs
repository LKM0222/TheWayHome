using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinUIScript : MonoBehaviour
{
    [SerializeField] Text[] priseText;

    SkinDataBase theSkinDB;
    Database theDB;

    [SerializeField] GameObject playerImg;
    

    // Start is called before the first frame update
    void Start()
    {
        theSkinDB = FindObjectOfType<SkinDataBase>();
        theDB = FindObjectOfType<Database>();


    }

    // Update is called once per frame
    void Update()
    {
        PriseSet();

        playerImg.GetComponent<SpriteRenderer>().sprite = theSkinDB.playerSprite[theDB.skinNum];
    }

    void PriseSet()
    {
        for(int i = 0; i < priseText.Length; i++)
        {
            if (!theSkinDB.buyFlag[i])
            {
                priseText[i].text = theSkinDB.prise[i].ToString();
            }
            else
            {
                priseText[i].text = "구매완료";
            }
        }

    }
}
