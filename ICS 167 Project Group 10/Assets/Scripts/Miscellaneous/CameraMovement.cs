using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * CameraMovement Script
 * @ Author: Yeeun Min
 */
public class CameraMovement : MonoBehaviour
{
    // Stores camera position value
    private static Vector3 cameraPosition;
   
    // variables to check if mouse hovers around the bottom of the map(min) and the top of the map(max)
    public static bool yEdgeMin, yEdgeMax;

    public static bool xEdgeMin, xEdgeMax;

    [Header("Camera Settings")]
    [SerializeField]
    private float cameraSpeed; // Adjustable camera movement speed
    [SerializeField]
    [Range(0.01f, 1f)]
    private float smoothSpeed = 0.125f; // Adjustable camera smoothness

    private Vector3 velocity = Vector3.zero;

    // Toggle to enable camera locking so the camera doesn't move beyond the designated bounds
    [SerializeField]
    private bool border;

    // Adjustable Y border location
    [SerializeField]
    private float minY, maxY; 
    // Start is called before the first frame update
    void Start()
    {
        // Get current camera position
        cameraPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        handleEdgeScrolling(); //Enable mouse edge scrolling feature
        handleBorder(); //Enable border handling
    }

    private void handleEdgeScrolling()
    {
        if( Input.mousePosition.x >= Screen.width * 0.154f && Input.mousePosition.x <= Screen.width * 0.846f)
        {
            // mouse touching the top 20% of the screen
            if (Input.mousePosition.y >= Screen.height * 0.8f)
            {
                cameraPosition.y += cameraSpeed / 20; //new camera position changes
                yEdgeMax = true; //mouse is touching the top part of the map
            }
            else
                yEdgeMax = false; //mouse is not touching the top part of the map

            // mouse touching the bottom 20% of the screen
            if (Input.mousePosition.y <= Screen.height * 0.2f)
            {
                cameraPosition.y -= cameraSpeed / 20; //new camera position changes
                yEdgeMin = true; //mouse is touching the bottom part of the map
            }
            else
                yEdgeMin = false; //mouse is not touchnig the bottom part of the map

            //update the current position to the new position
            this.transform.position = Vector3.SmoothDamp(transform.position, cameraPosition, ref velocity, smoothSpeed);
        }
        
    }

    private void handleBorder()
    {
        // camera border lock is enabled (check variable bool border for detailed definition)
        if (border == true)
        {
            //Force the current camera position to be on the designated min and max y location on the inspector
            transform.position = new Vector3(transform.position.x, 
                                             Mathf.Clamp(transform.position.y, minY, maxY), 
                                             transform.position.z);
        }
    }
}
