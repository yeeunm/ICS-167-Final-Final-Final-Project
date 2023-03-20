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
    private AudioClip m_MenuMusic;  //used for audio manager that is specifically for menu music.
    [SerializeField]
    private Player pl1 { get; set; } //player 1. Always a real player by default.
    [SerializeField]
    private Player pl2 { get; set; } //player 2. May be a real player or an AI depending on Menu.isSingle value.
    [SerializeField]
    public static bool isPl1Turn { get; set; } //tells if it's player 1's turn
    [SerializeField]
    public static bool isP2AI { get; set; } //variable that tells if Player 2 is AI.


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

    private GameObject winScreen;

    private static GameStateManager _instance;


    // Start is called before the first frame update
    void Start()
    {
        initializeGame();
    }

    // Update is called once per frame
    void Update()
    {
        adjustUnitLayer();
        announceWinner();
        
    }

    private void initializeGame()
    {
        //both unitList and unitLoc story 10 elements.
        unitList = new GameObject[10];
        unitLoc = new Vector3[10];
        

        //Assign Vector values into unitLoc array. 
        //Refer to unitLoc array declaration above for index clarification.
        unitLoc[0] = new Vector3(6, 3);
        unitLoc[1] = new Vector3(8, 1);
        unitLoc[2] = new Vector3(4, 6);
        unitLoc[3] = new Vector3(10, 3);
        unitLoc[4] = new Vector3(13, 3);
        unitLoc[5] = new Vector3(7, 18);
        unitLoc[6] = new Vector3(3, 18);
        unitLoc[7] = new Vector3(2, 14);
        unitLoc[8] = new Vector3(5, 17);
        unitLoc[9] = new Vector3(11, 18);

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
        pl1 = new Player(true, false, unitPrefabs[0], unitPrefabs[1], unitPrefabs[2], unitPrefabs[3], unitPrefabs[4]);

        //If single player, Player 2 is AI.
        if (Menu.isSingle)
        {
            pl2 = new Player(false, true, unitPrefabs[5], unitPrefabs[6], unitPrefabs[7], unitPrefabs[8], unitPrefabs[9]);
        }
        else//If it's not single player mode, Player 2 is a person.
        {
            pl2 = new Player(false, false, unitPrefabs[5], unitPrefabs[6], unitPrefabs[7], unitPrefabs[8], unitPrefabs[9]);
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

    private void alternateTurn()
    {
        isPl1Turn = !isPl1Turn;
        if(isPl1Turn)
        {
            for( int i = 0; i < 5; i++)
            {
                try
                {
                    unitList[i].GetComponent<Character>().unmoveable = false;
                    unitList[i + 5].GetComponent<Character>().unmoveable = true;
                }
                catch (MissingReferenceException)
                {
                    continue;
                }
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                try
                {
                    unitList[i].GetComponent<Character>().unmoveable = true;
                    unitList[i + 5].GetComponent<Character>().unmoveable = false;
                }
                catch (MissingReferenceException)
                {
                    continue;
                }
                
            }
        }
        for( int i = 0; i < 5; i++)
        {
            try
            {
                unitList[i].GetComponent<Character>().timesmoved = 0;
                unitList[i + 5].GetComponent<Character>().timesmoved = 0;
            }
            catch (MissingReferenceException)
            {
                continue;
            }
        }
        
        //Enable this code to check if winning condition works properly
        /*for( int i = 0; i < 5; i++)
        {
            if( unitList[i] != null)
            {
                Destroy(unitList[i]);
                Debug.Log($"Unit at index {i} is dead now. Uhoh");
                return;
            }
        }*/
    }
    
    
    private void adjustUnitLayer()
    {
        for( int i = 0; i < unitList.Length; i++)
        {
            try
            {
                unitList[i].GetComponent<SpriteRenderer>().sortingOrder = 20 - (int)unitLoc[i].y;
            }
            catch(MissingReferenceException)
            {
                continue;
            }
            
        }
    }

    private Player checkWinner()
    {
        bool unitAlive = false;
        for( int i = 0; i < 5; i++ )
        {
            if (unitList[i] != null)
                unitAlive = true;

            if (unitAlive)
                break;

        }
        if (!unitAlive)
            return pl2;
        else
           unitAlive = false;
        for (int i = 5; i < 10; i++)
        {
            if (unitList[i] != null)
                unitAlive = true;

            if (unitAlive)
                return null;
        }

        return pl1;

    }

    private void announceWinner()
    {
        Player winner = checkWinner();
        if (winner != null)
        {
            showWinScreen();
        }
    }

    public void showWinScreen()
    {
        winScreen.SetActive(true);
        Time.timeScale = 1f;
    }

}
