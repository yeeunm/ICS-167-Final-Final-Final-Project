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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void moveUnit()
    {
        timesMoved = 0;
        base.moveUnit();
    }

    public override void doAI()
    {
        base.doAI();
    }
}
