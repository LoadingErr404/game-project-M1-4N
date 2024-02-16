using System;
using TMPro;
using UnityEngine;

public class WriteText : MonoBehaviour
{
    [SerializeField] private string givenWord;
    [SerializeField] private TMP_Text textArea;
    private bool _writeOut;
    [SerializeField] private float writeOutDelay;
    private float _writeCounter;
    private int _position;


    private void Update()
    {
        if (!_writeOut)
        {
            return;
        }

        if (_writeCounter < writeOutDelay)
        {
            _writeCounter += Time.deltaTime;
            return;
        }
        
        if (_position >= givenWord.Length)
        {
            return;
        }
            
        _writeCounter = 0f;
        textArea.text += givenWord[_position++];
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _writeOut = true;
    }
}
