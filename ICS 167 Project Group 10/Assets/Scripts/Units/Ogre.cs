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
