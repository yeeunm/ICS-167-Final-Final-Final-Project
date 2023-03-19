using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Player Class Script
 * @Author: Asad Ellis
 *          Yeeun Min
 *          Ricardo Reyes
 */
public class Player
{
    [SerializeField]
    private bool isAI { get; set; }
    public GameObject[] team { get; set; }
    private bool[] deathList;
    public string name { get; set; }

    public Player(bool isP1, bool isAI, GameObject u1, GameObject u2, GameObject u3, GameObject u4, GameObject u5)
    {
        if (isP1)
            name = "Player 1";
        else
            name = "Player 2";
        this.isAI = isAI;
        team = new GameObject[5];
        team[0] = u1;
        team[1] = u2;
        team[2] = u3;
        team[3] = u4;
        team[4] = u5;

        if (isAI)
        {
            for( int i = 0; i < team.Length; i++)
            {
                team[i].GetComponent<Character>().isAI = true;
            }
        }

        deathList = new bool[5];
        for (int i = 0; i < deathList.Length; i++)
            deathList[i] = true;

    }


}
