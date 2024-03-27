using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{
    [SerializeField] GameObject debugger;

    public void OnDebuggerPopupClose()
    {
        debugger.SetActive(false);
    }

    public void OnDebuggerPopupOpen()
    {
        debugger.SetActive(true);
    }
}
