using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Escape : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // 20?? ?? ????
        Invoke("EscapeScene", 60.0f);
    }

    void EscapeScene()
    {
        // ???? ?????? ????
        SceneManager.LoadScene("MainScene");
    }
}
