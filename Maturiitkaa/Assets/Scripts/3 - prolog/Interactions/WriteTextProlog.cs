using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class WriteTextProlog : MonoBehaviour
{
    public string givenWord;
    [SerializeField] private TMP_Text textArea;
    public bool writeOut;
    [SerializeField] private float writeOutDelay;
    private float _writeCounter;
    private int _position;
    
    

    protected void Update()
    {
        if (!writeOut)
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
        writeOut = true;
       
    }
   
}
