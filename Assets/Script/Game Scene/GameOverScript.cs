using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    Database theDB;
    PlayerMovingButton thePlayer;
    public GameObject gameOverPopup;
    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
        thePlayer = FindObjectOfType<PlayerMovingButton>();
    }

    // Update is called once per frame
    void Update()
    {
        if(theDB.playerEnergy < 0f)
        {
            if (theDB.spareFuel)
            {
                thePlayer.PowerOverWhelming();
                theDB.playerEnergy = theDB.playerRevivalEnergy;
                theDB.spareFuel = false;
            }
            else
            {
                Time.timeScale = 0f;
                gameOverPopup.SetActive(true);
                theDB.gameoverFlag = true;

                //theDB.totalPlayerMoney += theDB.playerMoney;
            }
            
        }
    }
}
