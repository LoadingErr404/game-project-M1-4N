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
    public UnityEvent successfulInteraction;
    [SerializeField] private WriteTextProlog writeText;
    [SerializeField] public InteractTextPrologWritingSentences interactText;
    
    [Header("File")]
    private readonly List<string> _sentenceList = new();
    [SerializeField] private TextAsset myFile;
    private int _numberOfSentences;
    public bool interacting;
    
    [Header("Text fields")]
    [SerializeField] public TMP_Text ownTextField;
    [SerializeField] public WritingGameplayProlog writing;
    
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
        
        if (!interacting)
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
            writing.controlWordsProlog.canMove = true;
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
        interacting = true;
        writing.controlWordsProlog.stopWritingTimer = true;
        writing.controlWordsProlog.canMove = false;
        writing.ChangeTextArea(ownTextField);
        writeNewSentence = true;
        interactText.interactable = true;
    }

    public int ReturnNumOfLines()
    {
        return _sentenceList.Count;
    }
}
