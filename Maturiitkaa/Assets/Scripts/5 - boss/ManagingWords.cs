using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;

public class ManagingWords : MonoBehaviour
{
    [SerializeField] private TMP_Text text1;
    [SerializeField] private TMP_Text text2;
    [SerializeField] private TMP_Text text3;

    private void Start()
    {
        ClearTexts();
    }

    public void SetTexts(List<string> wordsList)
    {
        text1.SetText(wordsList[0]);
        text2.SetText(wordsList[1]);
        text3.SetText(wordsList[2]);
    }

    public void ClearTexts()
    {
        text1.SetText("");
        text2.SetText("");
        text3.SetText("");
    }

    public int ReturnLenghtLongest(List<string> wordsList)
    {
        if (wordsList[0].Length > wordsList[1].Length)
        {
            if (wordsList[0].Length > wordsList[2].Length)
            {
                return wordsList[0].Length;
            }
           
            return wordsList[2].Length;
        }

        if (wordsList[1].Length > wordsList[2].Length)
        {
            return wordsList[1].Length;
        }

        return wordsList[2].Length;
    }
    
    
}
