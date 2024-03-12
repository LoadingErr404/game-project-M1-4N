using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WriteOutSentences : MonoBehaviour
{
    //[SerializeField] private ControlWordsProlog controlWordsProlog;
    [SerializeField] private WriteTextProlog writeText;
    
    [Header("File")]
    private readonly List<string> _sentenceList = new();
    [SerializeField] private TextAsset myFile;
    private int _numberOfSentences;
    private bool _interacting;
    
    [Header("Text fields")]
    [SerializeField] private TMP_Text ownTextField;
    [SerializeField] private TMP_Text stableWordText;
    [SerializeField] private WritingGameplayProlog writing;
    
    private enum ReturnMeanings {EmptyWord, NotMatchingWord, MatchingWord};
    private int _position;
    private int _lastPosition = -1;
    public bool writeNewSentence;


    private void Start()
    {
        LoadStrings();
        _numberOfSentences = _sentenceList.Count;
    }

    // Update is called once per frame
    private void Update()
    {
        if (!_interacting)
        {
            return;
        }

        if (_lastPosition == _position)
        {
            return;
        }

        if (_position >= _numberOfSentences)
        {
            return;
        }

        if (!writeNewSentence)
        {
            return;
        }

        
        writeText.givenSentence = _sentenceList[_position++];
        Debug.Log("Position: "+ _position);

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

    private void OnTriggerEnter2D(Collider2D other)
    {
        _interacting = true;
        writing.controlWordsProlog.stopWritingTimer = true;
        writing.controlWordsProlog.canMove = false;
        writing.ChangeTextArea(ownTextField);
        writeNewSentence = true;
    }
    
    private int CheckIndexes(string textFromField)
    {
        if (textFromField.Length == 0)
        {
            return (int) ReturnMeanings.EmptyWord;
        }
        
        if (textFromField.Length > _sentenceList[_position].Length)
        {
            return (int)ReturnMeanings.NotMatchingWord;
        }
        
        for (var i = 0; i < textFromField.Length; i++)
        {
            if (textFromField[i] != _sentenceList[_position][i])
            {
                return (int)ReturnMeanings.NotMatchingWord;
            }
        }
        
        return (int)ReturnMeanings.MatchingWord;
    }
}
