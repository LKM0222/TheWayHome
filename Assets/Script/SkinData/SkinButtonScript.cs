using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinButtonScript : MonoBehaviour
{
    SkinDataBase theSkinDB;

    public GameObject equipMessage, buyMessage, scoreMessage;

    [SerializeField] int buttonNum;

    // Start is called before the first frame update
    void Start()
    {
        theSkinDB = FindObjectOfType<SkinDataBase>();
    }

    public void OnSkinButtonClick()
    {
        theSkinDB.clickNum = buttonNum;

        if (theSkinDB.buyFlag[theSkinDB.clickNum])
        {
            equipMessage.SetActive(true);
        }
        else
        {
            if (buttonNum != 6)
                buyMessage.SetActive(true);
            else
                scoreMessage.SetActive(true);
        }
    }
}
