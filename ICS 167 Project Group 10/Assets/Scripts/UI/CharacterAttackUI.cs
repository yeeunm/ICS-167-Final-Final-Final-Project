using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterAttackUI : MonoBehaviour
{
    private Vector3 mousePos;
    // Start is called before the first frame update
    void Start()
    {
        updateMousePos();
    }

    // Update is called once per frame
    void Update()
    {
        updateMousePos();
    }

    private void updateMousePos()
    {
        //Real mouse position in the screen world
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        this.transform.position = mousePos;
    }


}
