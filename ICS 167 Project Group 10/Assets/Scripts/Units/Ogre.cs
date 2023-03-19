using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ogre Script
 * @Author: Yeeun Min
 *          Samantha Purganan
 */
public class Ogre : Character
{
    // Start is called before the first frame update
    public Vector3 currentLoc;

    public bool isClicked;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 15;
        HP = maxHP;
        atk = 5;
        mov = 1;
    }

    // Update is called once per frame
    void Update()
    {
        mouseInteraction();
    }

}
