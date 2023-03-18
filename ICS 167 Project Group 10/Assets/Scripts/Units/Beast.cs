using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Beast Script
 * @Author: Yeeun Min
 *          Samantha Purganan
 */
public class Beast : Character
{
    // Start is called before the first frame update
    void Start()
    {
        maxHP = 10;
        HP = maxHP;
        atk = 4;
        mov = 3;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void doAI()
    {
        base.doAI();
    }
}
