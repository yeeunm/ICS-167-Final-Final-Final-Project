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
    protected bool isAI { get; set; }
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
    private bool isCursorClicked { get; set; }

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

    public virtual void moveUnit()
    {
        this.transform.Translate(Vector3.down);
        isActive = false;
    }

    public virtual void doAI()
    {
        isActive = false;
    }

    public void mouseClicked()
    {
        isCursorClicked = true;
    }
}
