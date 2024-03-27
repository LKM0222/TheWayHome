using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainButtonScript : MonoBehaviour
{
    public SpriteRenderer fadeImg;
    Database theDB;
    [SerializeField] Animator fadeAnimator;

    private void Start()
    {
        theDB = FindObjectOfType<Database>();
    }


    public void OnPlayButtonClick()
    {
        fadeImg.gameObject.SetActive(true);
        fadeAnimator.SetBool("StartFlag", true);
        StartCoroutine(FadeOut());
    }

    IEnumerator FadeOut()
    {
        Color fade = fadeImg.color;

        for (float ff = 0f; ff < 1f;)
        {
            ff += 0.01f;
            fade.a = ff;
            fadeImg.color = fade;
            yield return new WaitForSeconds(0.01f);

        }
        theDB.Init();
        SceneManager.LoadScene("GameScene");
        fadeAnimator.SetBool("StartFlag", false);

    }
}
