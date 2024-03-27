using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSetPanel : MonoBehaviour
{
    public GameObject setPanel;

    public void CloseSet()
    {
        if (setPanel != null)
        {
            setPanel.SetActive(false);
            Debug.Log("SetPanel_False");
        }
    }
}
