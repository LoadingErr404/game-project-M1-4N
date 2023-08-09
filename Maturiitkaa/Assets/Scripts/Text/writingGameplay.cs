using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class writingGameplay : MonoBehaviour
{
    public TMP_Text myText;
    private string myWord;

    // Start is called before the first frame update
    void Start()
    {
        ClearText();
        myWord="";
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.anyKeyDown){ //ošetři jenom pro písmena, čísla a základní znaky ang klávesnice
            foreach (char letter in Input.inputString){ //every possible key input
                Debug.Log(letter);
                buffWord(letter);
                Debug.Log(myWord);
                printWord();
            }
        }
    }

    private void ClearText(){ //clears output text
        myText.text="";
    }

    private void buffWord(char letter){ //buffers pressed characters
        if(letter != '\b'){
            myWord+=letter;
        }
        else{
            myWord = myWord.Remove(myWord.Length - 1);
        }
    }

    private void printWord(){
        myText.text=myWord;
    }

    
}


    