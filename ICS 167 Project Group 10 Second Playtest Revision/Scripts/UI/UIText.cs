using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIText : MonoBehaviour
{
    public string message;

    private void OnMouseEnter()
    {
        UIHandlerManager._instance.SetAndShowToolTip(message);
    }

    private void OnMouseExit()
    {
        UIHandlerManager._instance.HideToolTip();
    }
}
