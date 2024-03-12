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
    [SerializeField] public InteractTextPrologWritingSentences interactText;
    
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
    public int rowIndex;
    public bool writeNewSentence;
    public bool ableToWriteInto;


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
        
        if (!writeNewSentence)
        {
            return;
        }

        if (rowIndex < _numberOfSentences)
        {
            writeText.givenSentence = _sentenceList[rowIndex];
        }
        else
        {
            Destroy(gameObject); 
        }

        

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
        interactText.interactable = true;
    }
}
