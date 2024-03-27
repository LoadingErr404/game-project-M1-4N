using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class DadWriteOutsDeciding : MonoBehaviour
{
    [SerializeField] private TMP_Text textArea;
    private readonly List<string> _sentenceList = new();
    [SerializeField] private TextAsset winFile;
    [SerializeField] private TextAsset loseFile;
    [SerializeField] private float waitBetweenLetters;
    [SerializeField] private float waitBetweenSentences;
    
    public int numberOfLines;
    private int _numberPrinted;
    private string _index;
    
    [SerializeField] private ControlWordsBoss controls;
    [SerializeField] private MoveScreenUp moveScreen;
    [SerializeField] private int orderInQuery;
    

    private void Start()
    {
        //getting index from name of object
        _index = gameObject.ToString().Split('_')[1];
       
        
        StartCoroutine(PrintSentences());


    }

    private void LoadStrings()
    {
        var textFromFile = ""; //gets contents of file
        
        textFromFile = controls.dadHp > 0 ? loseFile.ToString() : winFile.ToString();
        
        var lines = textFromFile.Split(Environment.NewLine.ToCharArray());

        foreach (var line in lines)
        {
            if (!line.Equals(""))
            {
                _sentenceList.Add(line);
            }
            
        }

    }

    private IEnumerator PrintSentences()
    {
        yield return new WaitUntil(MyTime);
        LoadStrings();
        numberOfLines = _sentenceList.Count;
        controls.dadDoneWriting = false;

        
        
        //yield return new WaitUntil(SameIndexesDad);
        yield return new WaitUntil(controls.GetMilanDoneWriting);

        controls.showInteractInterface = false;
        foreach (var sentence in _sentenceList)
        {
            foreach (var t in sentence)
            {
                yield return new WaitForSeconds(waitBetweenLetters);
                textArea.text += t;
            }

            yield return new WaitForSeconds(waitBetweenSentences);
            textArea.text += "\n";
            _numberPrinted++;
            
        }
       
        yield return new WaitUntil(EverythingPrinted);
        
        
        controls.dadWritingIndex++;
        moveScreen.MoveUp(2.1f);
        controls.dadDoneWriting = true;
        controls.objectQuery++;

    }
    
    private bool SameIndexesDad() //cannot be in ControlWords - we cant have parameters
    {
        var writeIndex = controls.dadWritingIndex + 1; //names are from 1
        _index = _index.Split("_")[0]; //the rest is a mess from engine 
        return writeIndex.ToString().Equals(_index);
    }

    private bool EverythingPrinted()
    {
        return _numberPrinted == numberOfLines;
    }

    private bool MyTime()
    {
        return controls.objectQuery == orderInQuery;
    }

    public int NumOfSentences()
    {
        return _sentenceList.Count;
    }
}
