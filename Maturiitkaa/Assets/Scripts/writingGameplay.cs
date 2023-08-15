using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WritingGameplay : MonoBehaviour
{
    [Header("Text field")]
    public TMP_Text myText;
    
    private string _myWord;

    private MyTimer _myTimer; //object from script 'MyTimer'

    // Start is called before the first frame update
    void Start(){
        ClearText();
        _myWord="";
        _myTimer = GameObject.FindGameObjectWithTag("MyTimer").GetComponent<MyTimer>(); //assigning object to container via Tag
    }

    // Update is called once per frame
    void Update(){
        if(Input.anyKeyDown){ 
            foreach (char letter in Input.inputString){ //every possible key input
                BuffWord(letter); //checks if it is an allowed letter
                PrintWord();
            }
        }
        
        if (_myTimer.currentTime >= _myTimer.timerDelayTrigger){
            _myTimer.currentTime = 0.0;
            ClearText();
        }

        
    }

    private void ClearText(){ //clears output text
        myText.text="";
        _myWord = "";
    }

    private void BuffWord(char letter){ //buffers pressed characters
        if(letter >= 33 && letter <= 126 ){ //numbers representing ASCII characters from '!' to '~'
            _myWord+=letter;
        }
    }

    private void PrintWord(){
        myText.text=_myWord;
    }

    
}


    