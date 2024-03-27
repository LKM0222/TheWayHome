using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSkinPanel : MonoBehaviour
{
    public GameObject skinPanel;

    public void OpenSkin()
    {
        if (skinPanel != null)
        {
            skinPanel.SetActive(true);
            Debug.Log("SkinPanel_True");
        }
    }
}
