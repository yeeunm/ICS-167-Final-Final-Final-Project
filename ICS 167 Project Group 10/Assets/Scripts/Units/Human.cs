using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Human Script
 * @Author: Yeeun Min
 *          Samantha Purganan
 */
public class Human : Character
{
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 10;
        HP = maxHP;
        atk = 1;
        mov = 3;
        chInfo = $"HP: {HP} / {maxHP}\nAtk: {atk}\nMOV: {mov} / {mov}";
    }

    // Update is called once per frame
    void Update()
    {
        mouseInteraction();
        updateToString();
        checkDeath();
        AdjustLayer();
    }

    public override void doAI()
    {
        base.doAI();
    }

}
