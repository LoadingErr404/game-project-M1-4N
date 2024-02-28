using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteLines : MonoBehaviour
{
    [SerializeField] protected string givenWord;
    [SerializeField] private TMP_Text textArea;
    [SerializeField] private float writeOutDelay;
    [SerializeField] private float waitTime;
    private float _waitCounter;
    private float _writeCounter;
    private int _position;
    private int _count;
    private readonly List<string> _sentenceList = new();
    [SerializeField] private TextAsset myFile;
    

    private void Start()
    {
        LoadStrings();

    }
    
    protected void Update()
    {/*
        if (_count >= _sentenceList.Count)
        {
            return;
        }
        
        PrintSentence(_count);*/
        
        do
        { 
            _waitCounter += Time.deltaTime;
        } while (_waitCounter <= waitTime);
        _waitCounter = 0;
        Debug.Log("Wait over");


        //Wait();
        
        textArea.text = "";
        
        _position = 0;
        _count++;

    }

   

    private void LoadStrings()
    {
        var textFromFile = myFile.ToString(); //gets contents of file
        var lines = textFromFile.Split(Environment.NewLine.ToCharArray());

        foreach (var line in lines)
        {
            if (!line.Equals(""))
            {
                _sentenceList.Add(line);
            }
            
        }
    }

    private void PrintSentence(int count)
    {/*
        if (_writeCounter < writeOutDelay)
        {
            _writeCounter += Time.deltaTime;
            return;
        }

       
        
        if (_position >= _sentenceList[count].Length - 1)
        {
            return;
        }
*/
        while (_position < _sentenceList[count].Length)
        {
            while (_writeCounter < writeOutDelay)
            {
                _writeCounter += Time.deltaTime;
            }
            textArea.text += _sentenceList[_position++];
            _writeCounter = 0f;
        }
        /*
        _writeCounter = 0f;
        textArea.text += _sentenceList[_position++];*/
    }

    private void Wait()
    {/*
        if (_waitCounter < waitTime)
        {
            _waitCounter += Time.deltaTime;
            return false;
        }*/

        do
        { 
            _waitCounter += Time.deltaTime;
        } while (_waitCounter <= waitTime);

        _waitCounter = 0;
        Debug.Log("Wait over");
       // return true;

    }
}
