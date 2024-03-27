using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseSkinPanel : MonoBehaviour
{
    public GameObject skinPanel;

    public void CloseSkin()
    {
        if (skinPanel != null)
        {
            skinPanel.SetActive(false);
            Debug.Log("SkinPanel_False");
        }
    }
}
