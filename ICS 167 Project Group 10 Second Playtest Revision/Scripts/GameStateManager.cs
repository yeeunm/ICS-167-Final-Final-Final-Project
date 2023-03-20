using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

/**
 * GameStateManager Script
 * @Author: Asad Ellis
 *          Yeeun Min
 *          Ricardo Reyes
 */
public class GameStateManager : MonoBehaviour
{
    [SerializeField]
    private Player pl1 { get; set; } //player 1. Always a real player by default.
    [SerializeField]
    private Player pl2 { get; set; } //player 2. May be a real player or an AI depending on Menu.isSingle value.
    [SerializeField]
    public static bool isPl1Turn { get; set; } //tells if it's player 1's turn
    [SerializeField]
    public static bool isP2AI { get; set; } //variable that tells if Player 2 is AI


    //list of unit prefab objects for player 1 and player2.
    //Player 1 - unitPrefabs[0-4], Player 2 - unitPrefabs[5-9]
    [SerializeField]
    private GameObject[] unitPrefabs;

    //list of unit locations for player 1 and player2.
    //Player 1 - unitLoc[0-4], Player 2 - unitLoc[5-9]
    [SerializeField]
    private Vector3[] unitLoc { get; set; }

    //list of unit references that are spawned in the game, for player 1 and player2.
    //Player 1 - unitList[0-4], Player 2 - unitList[5-9]
    [SerializeField]
    private GameObject[] unitList { get; set; }

    //list of tile objects. The index of the nested array corresponds to the bottom left location of the tile.
    private GameObject[,] tileList { get; set; }

    private int timesMoved;
    private static GameStateManager _instance;


    // Start is called before the first frame update
    void Start()
    {
        initializeGame();
        timesMoved = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        adjustUnitLayer();
    }

    private void initializeGame()
    {
        //both unitList and unitLoc story 10 elements.
        unitList = new GameObject[10];
        unitLoc = new Vector3[10];
        

        //Assign Vector values into unitLoc array. 
        //Refer to unitLoc array declaration above for index clarification.
        for( int i = 0; i < unitList.Length; i++)
        {
            if (i < 5)
                unitLoc[i] = new Vector3((int)8.0f + i, 5.0f, 1.0f);
            else
                unitLoc[i] = new Vector3((int)13.0f - i, 18.0f, 1.0f);
        }

        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            for ( int i = 0; i < unitPrefabs.Length; i++ )
            {
                Destroy(unitPrefabs[i]);
            }
        }

        //Create new Player instance for Player 1
        pl1 = new Player(false, unitPrefabs[0], unitPrefabs[1], unitPrefabs[2], unitPrefabs[3], unitPrefabs[4]);

        //If single player, Player 2 is AI.
        if (Menu.isSingle)
        {
            pl2 = new Player(true, unitPrefabs[5], unitPrefabs[6], unitPrefabs[7], unitPrefabs[8], unitPrefabs[9]);
        }
        else//If it's not single player mode, Player 2 is a person.
        {
            pl2 = new Player(false, unitPrefabs[5], unitPrefabs[6], unitPrefabs[7], unitPrefabs[8], unitPrefabs[9]);
        }

        //Always start from Player 1 turn
        isPl1Turn = true;

        //Instantiate unit object references from both team.
        for (int i = 0; i < pl1.team.Length; i++)
        {
            DontDestroyOnLoad(pl1.team[i]);
            DontDestroyOnLoad(pl2.team[i]);
            unitList[i] = Instantiate(pl1.team[i], unitLoc[i], Quaternion.identity);
            unitList[i + 5] = Instantiate(pl2.team[i], unitLoc[i + 5], Quaternion.identity);
            unitList[i + 5].GetComponent<Character>().unmoveable = true;
        }
        
    }

    public void alternateTurn()
    {
        isPl1Turn = !isPl1Turn;
        if(isPl1Turn)
        {
            for( int i = 0; i < 5; i++)
            {
                unitList[i].GetComponent<Character>().unmoveable = false;
                unitList[i+5].GetComponent<Character>().unmoveable = true;
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                unitList[i].GetComponent<Character>().unmoveable = true;
                unitList[i + 5].GetComponent<Character>().unmoveable = false;
            }
        }
        for( int i = 0; i < 5; i++)
        {
            unitList[i].GetComponent<Character>().timesmoved = 0;
            unitList[i + 5].GetComponent<Character>().timesmoved = 0;
        }
        

    }
    
    
    public void adjustUnitLayer()
    {
        for( int i = 0; i < unitList.Length; i++)
        {
            unitList[i].GetComponent<SpriteRenderer>().sortingOrder = 20 - (int)unitLoc[i].y;
        }
    }

    public void initializeTiles()
    {

    }

}
