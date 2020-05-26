using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockClickScript : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        ClickScript.canClick = false;
    }

    private void OnMouseDown()
    {
        ClickScript.canClick = false;
    }
    private void OnMouseExit()
    {
        ClickScript.canClick = true;
    }

    private void OnMouseEnter()
    {
        ClickScript.canClick = false;
    }
}
