using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Elf Script
 * @Author: Yeeun Min
 *          Samantha Purganan
 */
public class Elf : Character
{
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 7;
        HP = maxHP;
        atk = 2;
        mov = 4;
        chInfo = $"HP: {HP} / {maxHP}\nAtk: {atk}\nMOV: {mov} / {mov}";
    }

    // Update is called once per frame
    void Update()
    {
        mouseInteraction();
        updateToString();
        checkDeath();
    }

    public override void doAI()
    { 
        base.doAI();
    }

}
