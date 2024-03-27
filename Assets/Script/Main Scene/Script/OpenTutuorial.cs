using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenTutuorial : MonoBehaviour
{
    public GameObject tutorialPanel;
    public GameObject tutorial_1;
    public GameObject tutorial_2;
    public GameObject tutorial_3;


    public void OpenTutorial()
    {
        if(tutorialPanel != null)
        {
            tutorialPanel.SetActive(true);
            Debug.Log("Actived Tutorial");
            tutorial_1.SetActive(true);
            Debug.Log("Open TT1");
            tutorial_2.SetActive(false);
            Debug.Log("Close TT2");
            tutorial_3.SetActive(false);
            Debug.Log("Close TT3");
        }
    }

    public void NextPage_TT1()
    {
        if (tutorialPanel != null)
        {
            tutorial_1.SetActive(false);
            Debug.Log("Close TT1");
            tutorial_2.SetActive(true);
            Debug.Log("Open TT2");
            tutorial_3.SetActive(false);
            Debug.Log("Close TT3");
        }
    }

    public void PriviousPage_TT2()
    {
        if (tutorialPanel != null)
        {
            tutorial_1.SetActive(true);
            Debug.Log("Open TT1");
            tutorial_2.SetActive(false);
            Debug.Log("Close TT2");
            tutorial_3.SetActive(false);
            Debug.Log("Close TT3");
        }
    }

    public void NextPage_TT2()
    {
        if (tutorialPanel != null)
        {
            tutorial_1.SetActive(false);
            Debug.Log("Close TT1");
            tutorial_2.SetActive(false);
            Debug.Log("Close TT2");
            tutorial_3.SetActive(true);
            Debug.Log("Open TT3");
        }
    }

    public void PriviousPage_TT3()
    {
        if (tutorialPanel != null)
        {
            tutorial_1.SetActive(false);
            Debug.Log("Close TT1");
            tutorial_2.SetActive(true);
            Debug.Log("Open TT2");
            tutorial_3.SetActive(false);
            Debug.Log("Close TT3");
        }
    }

    public void FinishTutorial()
    {
        if (tutorialPanel != null)
        {
            tutorialPanel.SetActive(false);
            Debug.Log("DeActivte Tutorial");
            tutorial_1.SetActive(true);
            Debug.Log("Open TT1");
            tutorial_2.SetActive(false);
            Debug.Log("Close TT2");
            tutorial_3.SetActive(false);
            Debug.Log("Close TT3");
        }
    }
}
