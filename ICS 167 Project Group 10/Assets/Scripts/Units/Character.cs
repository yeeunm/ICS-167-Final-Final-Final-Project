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
    public Vector3 currentLoc { get; set; }

    protected Vector3 posa;
    private bool isMoving;  //if our player is moving or not
    private Vector3 targetPos;
    private float timeToMove = 0.7f;
    public int possiblemovement = 2;
    public int timesmoved = 0;
    public Vector3 unitmousePos;
    public Vector3 unitappliedPosition;
    public bool unmoveable;
    protected bool cursorOnObj = false;
    protected string chInfo;

    // Start is called before the first frame update
    void Start()
    {
        posa = transform.position;
        if (Menu.isSingle)
            isAI = true;

    }

    // Update is called once per frame
    void Update()
    {
    }
    

    public virtual void doAI()
    {
        AIMove();
        unmoveable = true;
    }

    private void AIMove()
    {
        for ( int i = 0; i < mov; i++)
        {
            int temp = UnityEngine.Random.Range(0, 4);
            if( temp == 0)
            {
                StartCoroutine(MovePlayer(new Vector3(1,0 )));
            }
            else if (temp == 1)
            {
                StartCoroutine(MovePlayer(new Vector3(-1, 0)));
            }
            else if (temp == 2)
            {
                StartCoroutine(MovePlayer(new Vector3(0, 1)));
            }
            else
            {
                StartCoroutine(MovePlayer(new Vector3(0, -1)));
            }

        }
            
    }

    public void updateUnitPosition()  //updates the position of the characters based on the keys the playr is pressing
    {
        currentLoc = transform.position;
        if (timesmoved == mov)
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

        if (timesmoved == mov)
            cursorOnObj = false;

    }

    protected IEnumerator MovePlayer(Vector3 direction)
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
        if (Input.GetMouseButtonDown(1))
        {
            cursorOnObj = false;
        }
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
            
            if (cursorOnObj)
            {
                updateUnitPosition();
            }
            posa = transform.position;
        }
    }
    public void updateToString()
    {
        chInfo = $"HP: {HP} / {maxHP}\nAtk: {atk}\nMOV: {mov - timesmoved} / {mov}";
    }
    public void Attack(Character enemy)
    {
        enemy.HP -= atk;
    }

    public void GetDamage(int dmg)
    {
        HP -= dmg;
    }

    protected void Heal()
    {
        if (HP < maxHP)
            HP++;
    }


    protected void AdjustLayer()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 25 - (int)posa.y;
    }


    protected void checkDeath()
    {
        if (HP <= 0)
            Destroy(this.gameObject);
    }
    public void OnMouseEnter()
    {
        updateToString();
        UIHandlerManager._instance.SetAndShowToolTip(chInfo);
    }

    public void OnMouseExit()
    {
        UIHandlerManager._instance.HideToolTip();
    }
}
