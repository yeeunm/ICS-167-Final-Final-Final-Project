using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    protected int mov { get; set; }
    public bool isActive { get; set; }
    [SerializeField]
    private SpriteRenderer sprite;
    public Vector3 currentLoc { get; set; }
    [SerializeField]
    protected int timesMoved;
    [SerializeField]
    public bool isCursorClicked { get; set; }

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

    public virtual void act()
    {   if( Input.GetKeyDown(KeyCode.W))
        {
            this.transform.Translate(Vector3.up);
            Debug.Log("You don't see this, don't you?");
        }
        if( Input.GetKeyDown(KeyCode.A))
        {
            this.transform.Translate(Vector3.left);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            this.transform.Translate(Vector3.down);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            this.transform.Translate(Vector3.right);
        }
    }
    

    public virtual void doAI()
    {
        this.transform.Translate(Vector3.down);
        isActive = false;
    }

}
