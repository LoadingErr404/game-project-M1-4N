using UnityEngine;
using TMPro;

public class WritingGameplay : MonoBehaviour
{
    [Header("Text field")]
    [SerializeField] private TMP_Text myText;
    
    private string _myWord;

    private MyTimer _myTimer; //object from script 'MyTimer'

    
    private void Start(){
        ClearText();
        _myWord="";
        _myTimer = GameObject.FindGameObjectWithTag("MyTimer").GetComponent<MyTimer>(); //assigning object to container via Tag
    }

    
    private void Update(){
        if(Input.anyKeyDown){ 
            foreach (var letter in Input.inputString){ //every possible key input
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
        _myWord = "";
        myText.text="";
    }

    private void BuffWord(char letter){ //buffers pressed characters
        if(letter >= 32 && letter <= 126 ){ //numbers representing ASCII characters from 'space' to '~'
            _myWord+=letter;
        }
    }

    private void PrintWord(){
        myText.text=_myWord;
    }

    
}


    