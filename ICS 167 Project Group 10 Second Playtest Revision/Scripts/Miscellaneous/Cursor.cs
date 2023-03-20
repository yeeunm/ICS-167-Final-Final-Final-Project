using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Cursor Script
 * @Author: Yeeun Min
 */
public class Cursor : MonoBehaviour
{

    private Vector3 mousePos; // actual mouse position
    private Vector3 appliedPosition; // mouse position respect to the grid system.
    private Vector3 velocity = Vector3.zero;
    [SerializeField]
    private float smoothSpeed = 0.01f; // cursor movement smoothness;
    [SerializeField]
    private Sprite defaultSprite; // default cursor sprite
    [SerializeField]
    private Sprite selectedSprite; // cursor sprite when clicked
    private SpriteRenderer sr; // reference variable to SpriteRenderer
    //variables to limit the cursor movement. If the mouse clicks beyond the map, the cursor will not shrink.
    [SerializeField]
    private float xEdgeMin, xEdgeMax;
    private bool canMove { get; set; }
    private bool isOnCharacter { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        sr = this.GetComponent<SpriteRenderer>();
        canMove = true;
        updatePosition();

    }

    // Update is called once per frame
    void Update()
    {
        updatePosition();
    }

    private void updatePosition()
    {
        //Real mouse position in the screen world
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //Applied position variable used to store the coordinates. Round down to nearest whole number.
        appliedPosition = new Vector3((int)Math.Floor(mousePos.x), (int)Math.Floor(mousePos.y));

        if (appliedPosition.x > xEdgeMax)
            appliedPosition.x = xEdgeMax;
        if (appliedPosition.x < xEdgeMin)
            appliedPosition.x = xEdgeMin;

        //As long as the mouse is not clicked, the cursor will follow the current mouse position.
        if (canMove)
            this.transform.position = Vector3.SmoothDamp(transform.position, appliedPosition, ref velocity, smoothSpeed);

        if( mousePos.x <= xEdgeMax && mousePos.x >= xEdgeMin)
            manageMouseClick();
    }

    private void manageMouseClick()
    {
        //Left mouse clicked; locks the cursor on the selected location.
        if (canMove && Input.GetMouseButtonDown(0))
        {
            sr.sprite = selectedSprite;
            this.transform.position = appliedPosition;
            canMove = false;
        }
        //Right mouse clicked; unlocks the cursor from the selected location.
        if (!canMove && Input.GetMouseButtonDown(1))
        {
            sr.sprite = defaultSprite;
            canMove = true;
        }

    }

    public float getX()
    {
        return transform.position.x;
    }

    public float getY()
    {
        return transform.position.y;
    }
}
