using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//this on 'main'Canvas of MainScene 

public class MainUIScript : MonoBehaviour
{
    public Text itemText;
    public Text moneyText;
    public Text highScoreText;
    public GameObject wingBlock, fuelBlock, shieldBlock;

    Database theDB;

    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
    }

    // Update is called once per frame
    void Update()
    {
        moneyText.text = string.Format("{0:#,0}", theDB.totalPlayerMoney);
        highScoreText.text = string.Format("{0:#,0}", Mathf.Round(theDB.highScore));


        switch (theDB.itemCode)
        {
            case 0:
                itemText.text = "부활 아이템을 구입하시겠습니까?";
                break;

            case 1:
                itemText.text = "추가연료를 구입하시겠습니까?";
                break;

            case 2:
                itemText.text = "방어막을 구입하시겠습니까?";
                break;

        }

        if (theDB.spareFuel)
            wingBlock.SetActive(true);
        else
            wingBlock.SetActive(false);

        if (theDB.addedFuel)
            fuelBlock.SetActive(true);
        else
            fuelBlock.SetActive(false);

        if (theDB.shield)
            shieldBlock.SetActive(true);
        else
            shieldBlock.SetActive(false);

    }
}
