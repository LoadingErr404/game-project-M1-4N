using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class WriteOutSentencesBoss : MonoBehaviour
{
    public UnityEvent successfulInteraction;
    [SerializeField] private WriteTextBoss writeText;
    [SerializeField] public InteractTextBossWritingSentences interactText;
    
    [Header("File")]
    private readonly List<string> _sentenceList = new();
    [SerializeField] private TextAsset myFile;
    private int _numberOfSentences;
    public bool interacting;
    
    [Header("Text fields")]
    [SerializeField] private TMP_Text ownTextField;
    [SerializeField] private MoveScreenUp screenController;
    public WritingGameplayBoss writing;
    
    public int rowIndex;
    public bool writeNewSentence;
    public bool ableToWriteInto;
    private string _index;


    private void Start()
    {
        LoadStrings();
        _numberOfSentences = _sentenceList.Count;
        _index = gameObject.ToString().Split('_')[1];
        StartCoroutine(WaitForAction());

    }

    // Update is called once per frame
    private void Update()
    {
        if (!writeNewSentence)
        {
            return;
        }
        
       
        if (rowIndex < _numberOfSentences)
        {
            writeText.givenSentence = _sentenceList[rowIndex];
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
    

    private bool CheckIndexes()
    {
        var writeIndex = screenController.controls.milanWritingIndex + 1; //names are from 1
        _index = _index.Split("_")[0]; //the rest is a mess from engine 
        return writeIndex.ToString().Equals(_index);
    }

    private IEnumerator WaitForAction()
    {
        yield return new WaitUntil(CheckIndexes);
        yield return new WaitUntil(screenController.controls.GetDadWriting);

        screenController.controls.milanDoneWriting = false;
        interactText.interactable = true;
        writing.ChangeTextArea(ownTextField);
        writeNewSentence = true;
    }
    
}
