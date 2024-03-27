using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSetPanel : MonoBehaviour
{
    public GameObject setPanel;

    public void OpenSet()
    {
        if(setPanel != null)
        {
            setPanel.SetActive(true);
            Debug.Log("SetPanel_True");
        }
    }
}
