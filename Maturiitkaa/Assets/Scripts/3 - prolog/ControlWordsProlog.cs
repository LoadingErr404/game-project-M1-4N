using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWordsProlog : MonoBehaviour
{
    public bool canMove = false;
    public bool stopWritingTimer = false;

    public bool GetCanMove()
    {
        return canMove;
    }
    
    public void SetCanMove(bool value)
    {
        canMove = value;
    }
}
