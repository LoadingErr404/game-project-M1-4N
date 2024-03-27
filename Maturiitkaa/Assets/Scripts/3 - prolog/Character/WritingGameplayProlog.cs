using UnityEngine;
using TMPro;
using UnityEngine.Serialization;

public class WritingGameplayProlog : MonoBehaviour
{
    [SerializeField] public ControlWordsProlog controlWordsProlog;
    
    
    [Header("Text field")]
    [SerializeField] private TMP_Text myTextArea;
    private TMP_Text _defaultTextArea;
    [SerializeField] private float writeOutFlush;
    private float _writeCounter;

    
    private void Start()
    {
        _defaultTextArea = myTextArea;
        
        ClearText();
    }

    
    private void Update(){
       
        if(Input.anyKeyDown){ 
            foreach (var letter in Input.inputString){ //every possible key input
                BuffWord(letter); //checks if it is an allowed letter
            }
        }

        if (controlWordsProlog.stopWritingTimer) //stops counting timer if we are interacting with objects
        {
            return;
        }
        
        if (_writeCounter >= writeOutFlush)
        {
            _writeCounter = 0;
            ClearText();
        }

        _writeCounter += Time.deltaTime;

    }

    public void ClearText(){ //clears output text
        myTextArea.text="";
    }

    private void BuffWord(char letter){ //buffers pressed characters
       /* if (Input.GetKey(KeyCode.LeftShift))
        {
            return;
        }*/
        
        if(letter >= 32 && letter <= 126 ){ //numbers representing ASCII characters from 'space' to '~'
            myTextArea.text += char.ToLower(letter);
            
        }
    }


    public void ChangeTextArea(TMP_Text newTextArea)
    {
        ClearText();
        myTextArea = newTextArea;
    }

    public void UseDefaultTextArea()
    {
        ClearText();
        myTextArea = _defaultTextArea;
    }

    public string ReturnText()
    {
        return myTextArea.text;
    }

    
}


    