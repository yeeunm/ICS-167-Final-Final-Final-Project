using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/**
 * Character Script
 * @Author: Asad Ellis
 *          Yeeun Min
 */
public abstract class Character : MonoBehaviour
{
    public bool isAI { get; set; }
    protected int HP { get; set; } 
    protected int maxHP { get; set; }
    protected int atk { get; set; } 
    public int mov { get; set; }
    public bool isActive { get; set; }
    [SerializeField]
    private SpriteRenderer sprite;
    public Vector3 currentLoc { get; set; }
    [SerializeField]
    public int timesMoved { get; set; }
    private bool isMoving;  //if our player is moving or not
    private Vector3 targetPos;
    private float timeToMove = 0.7f;
    public bool Cursorclicked = false;
    public int possiblemovement = 2;
    public int timesmoved = 0;
    public Vector3 unitmousePos;
    public Vector3 unitappliedPosition;
    public bool unmoveable;
    protected Vector3 posa;
    protected bool cursorOnObj = false;

    // Start is called before the first frame update
    void Start()
    {
        if (Menu.isSingle)
            isAI = true;

    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public virtual void doAI()
    {
        unmoveable = true;
    }

    public void updateUnitPosition()  //updates the position of the characters based on the keys the playr is pressing
    {
        currentLoc = transform.position;
        if (timesmoved == possiblemovement)
        {
            unmoveable = true;
        }
        if (Input.GetKey(KeyCode.W) && !isMoving && currentLoc.y != 19)
        {
            timesmoved += 1;
            StartCoroutine(MovePlayer(Vector3.up));
        }
        if (Input.GetKey(KeyCode.A) && !isMoving && currentLoc.x != 0)
        {
            timesmoved += 1;
            StartCoroutine(MovePlayer(Vector3.left));
        }
        if (Input.GetKey(KeyCode.S) && !isMoving && currentLoc.y != 0)
        {
            timesmoved += 1;
            StartCoroutine(MovePlayer(Vector3.down));
        }
        if (Input.GetKey(KeyCode.D) && !isMoving && currentLoc.x != 19)
        {
            timesmoved += 1;
            StartCoroutine(MovePlayer(Vector3.right));
        }

        Debug.Log($"TimesMoved: {timesmoved}");
    }

    private IEnumerator MovePlayer(Vector3 direction)
    {
        isMoving = true;

        //keeping track of the elapsed time
        float elapsedTime = 0;

        currentLoc = transform.position;
        targetPos = currentLoc + direction;

        //makes sure we lerp from the original position to the target pos, in the exact time we move
        while (elapsedTime < timeToMove)
        {
            transform.position = Vector3.Lerp(currentLoc, targetPos, (elapsedTime / timeToMove));
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = targetPos;

        isMoving = false;
    }

    protected void mouseInteraction()
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
