using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSceneButton : MonoBehaviour
{
    Database theDB;
    AdsScript ad;

    [SerializeField] GameObject pausePopup;

    private void Start()
    {
        theDB = FindObjectOfType<Database>();
        ad = FindObjectOfType<AdsScript>();
    }

    public void OnRestartButton()
    {
        Time.timeScale = 1f;
        theDB.Init();
        theDB.spareFuel = false;
        theDB.addedFuel = false;
        theDB.shield = false;
        theDB.adCount += 1;
        SceneManager.LoadScene("GameScene");
        
    }

    public void OnGotoRobbyButton()
    {
        Time.timeScale = 1f;
        theDB.Init();
        theDB.spareFuel = false;
        theDB.addedFuel = false;
        theDB.shield = false;
        theDB.adCount += 1;
        SceneManager.LoadScene("MainScene");

    }

    public void OnPauseButton()
    {
        Time.timeScale = 0f;
        pausePopup.SetActive(true);

    }

    public void OnResumeButton()
    {
        Time.timeScale = 1f;
        pausePopup.SetActive(false);

    }
}
