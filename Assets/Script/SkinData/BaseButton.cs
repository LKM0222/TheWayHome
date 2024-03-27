using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseButton : MonoBehaviour
{
    public GameObject equipMessage, buyMessage , errorMessage, scoreMessage;

    Database theDB;
    SkinDataBase theSkinDB;

    [SerializeField] int buttonNum;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
        theSkinDB = FindObjectOfType<SkinDataBase>();
    }

    public void OnCloseButton()
    {
        equipMessage.SetActive(false);
        buyMessage.SetActive(false);
    }

    public void OnScoreMessageCancle()
    {
        scoreMessage.SetActive(false);
    }

    //장착 버튼을 눌렀을 때 플레이어의 스킨을 바꾸는 코드
    public void OnEquipButtonClick()
    {
        buttonNum = theSkinDB.clickNum;
        theDB.skinNum = buttonNum;
        equipMessage.SetActive(false);
        print("Equip " + theDB.skinNum);
    }

    //구매 버튼을 눌렀을 때 DB의 구매 플래그를 바꾸는 코드
    public void OnBuyButtonClick()
    {
        buttonNum = theSkinDB.clickNum;

        if (theDB.totalPlayerMoney >= theSkinDB.prise[buttonNum])
        {
            theDB.totalPlayerMoney -= theSkinDB.prise[buttonNum];
            theSkinDB.buyFlag[buttonNum] = true;
            buyMessage.SetActive(false);
            theSkinDB.SkinFlagSet(buttonNum);
            theDB.GameDataSave();
        }
        else
        {
            errorMessage.SetActive(true);
        }

    }


    public void OnErrorButtonCancle()
    {
        buyMessage.SetActive(false);
        errorMessage.SetActive(false);
    }
}
