using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Fairy Script
 * @Author: Yeeun Min
 *          Samantha Purganan
 */
public class Fairy : Character
{
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 6;
        HP = maxHP;
        atk = 2;
        mov = 5;
        chInfo = $"HP: {HP} / {maxHP}\nAtk: {atk}\nMOV: {mov} / {mov}";
    }

    // Update is called once per frame
    void Update()
    {
        mouseInteraction();
        updateToString();
    }
}
    
