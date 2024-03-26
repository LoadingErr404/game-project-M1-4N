using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WriteTextProlog : MonoBehaviour
{
    public string givenSentence;
    [SerializeField] private TMP_Text textArea;
    [SerializeField] private float writeOutDelay;
    private float _writeCounter;
    private int _position;
    [SerializeField] private WriteOutSentences writeOutSentences;
    private int _lastRowIndex;
    private string _lastSentence;

    private void Start()
    {
        _lastSentence = "";
        _lastRowIndex = -1;
    }

    private void Update()
    {
        if (!writeOutSentences.writeNewSentence)
        {
            return;
        }

        if (_writeCounter < writeOutDelay)
        {
            
            _writeCounter += Time.deltaTime;
            return;
        }

        if (_lastRowIndex == writeOutSentences.rowIndex)
        {
            return;
        }
        
        if (_lastSentence.Equals(givenSentence))
        {
            return;
        }
        
        if (_position >= givenSentence.Length)
        {
            _lastRowIndex = writeOutSentences.rowIndex;
            _lastSentence = givenSentence;
            writeOutSentences.writeNewSentence = false;
            writeOutSentences.interactText.textForInteraction = givenSentence;
            writeOutSentences.ableToWriteInto = true;
            _position = 0;
            
            return;
        }
       
        
        textArea.text += givenSentence[_position++];
        writeOutSentences.ableToWriteInto = false;    
        _writeCounter = 0f;
        

    }
    
}
