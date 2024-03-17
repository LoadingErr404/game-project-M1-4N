using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWordsProlog : MonoBehaviour
{
    public bool canMove = true;
    public bool stopWritingTimer = false;
    public bool pictureOverlay = false;
    public int numberOfInteractedObjects = 0;
    public bool hasBook;
    public bool activateNextLevelTrigger;

    public void SetNextLevelToTrue()
    {
        activateNextLevelTrigger = true;
    }
}
