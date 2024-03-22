using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ControlWordsBoss : MonoBehaviour
{
    public bool dadDoneWriting;
    public bool milanDoneWriting;
    public int dadWritingIndex;
    public int milanWritingIndex;
    public int objectQuery;
    public bool showInteractInterface;
    public int dadHp;
    

    private void Start()
    {
        dadHp = 40;
    }

    private void Update()
    {
        if (objectQuery < 24)
        {
            return;
        }
        
        SceneManager.LoadScene(dadHp <= 0 ? "8 - win" : "9 - lose");
    }


    public bool GetMilanDoneWriting()
    {
        return milanDoneWriting;
    }

    public bool GetDadDoneWriting()
    {
        return dadDoneWriting;
    }
    
}
