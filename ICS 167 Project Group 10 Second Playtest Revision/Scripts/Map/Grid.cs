using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Grid Script
 * @Author: Yeeun Min
 */
public class Grid : MonoBehaviour
{
    private SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //G is a toggle key to enable/disable the grid from the screen
        if (Input.GetKeyDown(KeyCode.G))
            sr.enabled = !sr.enabled;
    }
}
