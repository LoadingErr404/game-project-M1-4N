using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlWordsBoss : MonoBehaviour
{
    public bool dadDoneWriting;
    public bool milanDoneWriting;
    public bool moveUp;
    public int dadWritingIndex;
    public int milanWritingIndex;

    public bool GetMilanWriting()
    {
        return milanDoneWriting;
    }
}
