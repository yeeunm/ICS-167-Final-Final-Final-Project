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
    void Start()
    {
        maxHP = 15;
        HP = maxHP;
        atk = 5;
        mov = 1;
        chInfo = $"HP: {HP} / {maxHP}\nAtk: {atk}\nMOV: {mov} / {mov}";
    }

    // Update is called once per frame
    void Update()
    {
        mouseInteraction();
        updateToString();
    }

}
