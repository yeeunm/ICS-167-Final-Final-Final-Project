using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/**
 * UIButton Script
 * @Author: Yeeun Min
 *          Ricardo Reyes
 */
public class UIButton : MonoBehaviour
{
    [SerializeField]
    Text buttonText;

    public void mouseClick()
    {
        if (GameStateManager.isPl1Turn)
        {
            buttonText.text = "End Player 1 Phase";
        }
        else
        {
            buttonText.text = "End Player 2 Phase";
        }

    }
}
