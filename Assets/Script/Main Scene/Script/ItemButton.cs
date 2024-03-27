using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    Database theDB;

    public GameObject itemPopup;
    public GameObject errorPopup;
    public int itemCode;

    bool enoughMoney = false;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
    }

    //아이템 팝업을 열고 나서 시작
    public void OnItemButtonClick()
    {
        errorPopup.SetActive(false);
        itemPopup.SetActive(true);
        theDB.itemCode = itemCode;
    }

    public void OnCancleButtonClick()
    {
        itemPopup.SetActive(false);
    }

    public void OnBuyButtonClick()
    {
        switch (theDB.itemCode)
        {
            case 0:
                if (theDB.totalPlayerMoney >= theDB.item_spareFuel)
                {
                    theDB.totalPlayerMoney -= theDB.item_spareFuel;
                    itemPopup.SetActive(false);
                    theDB.spareFuel = true;
                    theDB.revivalSoundFlag = true;
                    //enoughMoney = true;
                }
                    
                else
                    errorPopup.SetActive(true);
                break;

            case 1:
                if (theDB.totalPlayerMoney >= theDB.item_addedFuel)
                {
                    theDB.totalPlayerMoney -= theDB.item_addedFuel;
                    itemPopup.SetActive(false);
                    theDB.addedFuel = true;
                    //enoughMoney = true;
                }
                else
                    errorPopup.SetActive(true);
                break;

            case 2:
                if (theDB.totalPlayerMoney >= theDB.item_shield)
                {
                    theDB.totalPlayerMoney -= theDB.item_shield;
                    itemPopup.SetActive(false);
                    theDB.shield = true;
                    //enoughMoney = true;
                }
                else
                    errorPopup.SetActive(true);
                break;

        }

    }
    

}
