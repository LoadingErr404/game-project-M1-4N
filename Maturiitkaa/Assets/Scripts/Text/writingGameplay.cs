using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class writingGameplay : MonoBehaviour
{
    public TMP_Text myText;

    // Start is called before the first frame update
    void Start()
    {
        ClearText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ClearText(){ //clears output text
        myText.text="";
    }

    private char BufferLetter(){
        char letter = Input.GetKey(KeyCode.Return);
    }
}
