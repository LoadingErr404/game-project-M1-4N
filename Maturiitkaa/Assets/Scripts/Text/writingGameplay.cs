using System;
using System.Collections;

using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class WritingGameplay : MonoBehaviour
{
    public TMP_Text myText;
    private string MyWord;

    // Start is called before the first frame update
    void Start()
    {
        ClearText();
        MyWord="";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){ 
            foreach (char letter in Input.inputString){ //every possible key input
                BuffWord(letter); //checks if it is an allowed letter
                PrintWord();
            }
        }
    }

    private void ClearText(){ //clears output text
        myText.text="";
    }

    private void BuffWord(char letter){ //buffers pressed characters
        if(letter >= 33 && letter <= 126 ){ //numbers representing ASCII characters from '!' to '~'
            MyWord+=letter;
        }
    }

    private void PrintWord(){
        myText.text=MyWord;
    }

    
}


    