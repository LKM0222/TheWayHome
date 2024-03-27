using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleBackSpace : MonoBehaviour
{
    int EscapeCount = 0;
    public GameObject YesButton, NoButton, EscPanel;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            EscapeCount++;
            Debug.Log("ESC Count 1");
            /*if (!IsInvoking("DoubleClick"))
            { 
                Invoke("DoubleClick", 1.0f);
            }*/
            if(EscPanel != null)
            {
                EscPanel.SetActive(true);
                Debug.Log("EscPanel_True");
                Time.timeScale = 0;
                Debug.Log("Pause");
            }               
        }
        else if (EscapeCount == 2)
        {
           // CancelInvoke("DoubleClick");
            Debug.Log("ESC Count 2");        
            EscapeCount = 0;
            Debug.Log("ESC Count 0");
            Application.Quit();
            Debug.Log("Program Quit");
        }
    }

    /*void DoubleClick()
    {
        EscapeCount = 0;
        Debug.Log("ESC Count 0");
    }*/

    public void PressYes()
    {
        EscapeCount = 0;
        Debug.Log("Press Yes");
        Debug.Log("Program Quit and EscapeCount Set 0");
        Application.Quit();
    }

    public void PressNo()
    {
        EscapeCount = 0;
        Debug.Log("Press No");
        Debug.Log("EscapeCount Set 0");
        if(EscPanel != null)
        {
            EscPanel.SetActive(false);
            Debug.Log("EscPanel_False");
            Time.timeScale = 1;
            Debug.Log("Continue");
        }
    }
}
