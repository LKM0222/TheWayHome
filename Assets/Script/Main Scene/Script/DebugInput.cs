using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugInput : MonoBehaviour
{
    Database theDB;

    [SerializeField] InputField playerMaxSpeed;
    [SerializeField] InputField playerUpSpeed;
    [SerializeField] InputField fixMapMovingSpeed;
    [SerializeField] InputField mapMovingSpeed;

    [SerializeField] InputField playerConsumeEnergy;
    [SerializeField] InputField playerEnergy;
    [SerializeField] InputField playerMaxEnergy;
    [SerializeField] InputField playerRevivalEnergy;
    [SerializeField] InputField wormholeEnergy;
    [SerializeField] InputField wallHitEnergy;
    [SerializeField] InputField downConsumeEnergy;
    [SerializeField] InputField dangerExitEnergy;

    [SerializeField] InputField totalPlayerMoney;

    [SerializeField] InputField playerPlusScore;
    [SerializeField] InputField zodiacScore;
    [SerializeField] InputField smallStarScore;
    [SerializeField] InputField bigStarScore;
    



    public void InputMaxSpeed()
    {
        theDB.playerMaxSpeed = float.Parse(playerMaxSpeed.text);
    }

    public void InputPlayerSpeed()
    {
        theDB.playerUpSpeed = float.Parse(playerUpSpeed.text);
    }

    public void InputFixMapMovingSpeed()
    {
        theDB.fixMapMovingSpeed = float.Parse(fixMapMovingSpeed.text);
    }

    

    public void InputPlayerConsumeEnergy()
    {
        theDB.playerConsumeEnergy = float.Parse(playerConsumeEnergy.text);
    }

    public void InputPlayerEnergy()
    {
        theDB.playerEnergy = float.Parse(playerEnergy.text);
    }

    public void InputPlayerMaxEnergy()
    {
        theDB.playerMaxEnergy = float.Parse(playerMaxEnergy.text);
    }

    public void InputPlayerRevivalEnergy()
    {
        theDB.playerRevivalEnergy = float.Parse(playerRevivalEnergy.text);
    }

    public void InputWormholeEnergy()
    {
        theDB.wormholeEnergy = float.Parse(wormholeEnergy.text);
    }

    public void InputWallHitEnergy()
    {
        theDB.wallHitEnergy = float.Parse(wallHitEnergy.text);
    }

    public void InputDownConsumeEnergy()
    {
        theDB.downConsumeEnergy = float.Parse(downConsumeEnergy.text);
    }

    public void InputTotalPlayerMoney()
    {
        theDB.totalPlayerMoney = int.Parse(totalPlayerMoney.text);
    }

    public void InputPlayerPlusScore()
    {
        theDB.playerPlusScore = float.Parse(playerPlusScore.text);
    }

    public void InputZodiacScore()
    {
        theDB.zodiacScore = float.Parse(zodiacScore.text);
    }

    public void InputSmallStarScore()
    {
        theDB.smallStarScore = float.Parse(smallStarScore.text);
    }

    public void InputBigStarScore()
    {
        theDB.bigStarScore = float.Parse(bigStarScore.text);
    }

    public void InputDangerExitEnergy()
    {
        theDB.dangerExitEnergy = float.Parse(dangerExitEnergy.text);
    }


    // Start is called before the first frame update
    void Start()
    {
        theDB = FindObjectOfType<Database>();
    }

}
