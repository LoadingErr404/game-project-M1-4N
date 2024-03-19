using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWordsBoss : MonoBehaviour
{
    public bool dadDoneWriting;
    public bool milanDoneWriting;
    public int dadWritingIndex;
    public int milanWritingIndex;
    public int nextLevel;

    public enum NextLevelIdentifiers
    {
        SameLevel,
        WinLevel,
        LooseLevel
    };

    private void Start()
    {
        nextLevel = (int)NextLevelIdentifiers.SameLevel;
    }


    public bool GetMilanWriting()
    {
        return milanDoneWriting;
    }

    public bool GetDadWriting()
    {
        return dadDoneWriting;
    }
    
}
