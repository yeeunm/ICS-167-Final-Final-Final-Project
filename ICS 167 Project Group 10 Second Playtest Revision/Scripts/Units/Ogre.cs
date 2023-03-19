using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Ogre Script
 * @Author: Asad Ellis
 *          Yeeun Min
 *          Samantha Purganan
 */
public class Ogre : Character
{
    public Vector3 posa;
    public bool cursorOnObj = false;
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
        posa = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (unmoveable == false)
        {
            unitmousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //Applied position variable used to store the coordinates. Round down to nearest whole number.
            unitappliedPosition = new Vector3((int)Math.Floor(unitmousePos.x), (int)Math.Floor(unitmousePos.y));
            if (Input.GetMouseButtonDown(0))
            {
                if (unitappliedPosition.x == posa.x && unitappliedPosition.y == posa.y)
                {
                    cursorOnObj = true;
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                cursorOnObj = false;
            }
            if (cursorOnObj)
            {
                updateUnitPosition();
            }
            posa = transform.position;
        }
    }

}
