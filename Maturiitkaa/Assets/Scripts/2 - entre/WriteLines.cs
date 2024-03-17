using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WriteLines : MonoBehaviour
{
    [SerializeField] private TMP_Text textArea;
    private readonly List<string> _sentenceList = new();
    [SerializeField] private TextAsset myFile;
    [SerializeField] private float waitBetweenLetters;
    [SerializeField] private float waitBetweenSentences;
    [SerializeField] private LoadNextLevel loadNextLevel;
    

    private void Start()
    {
        LoadStrings();
        StartCoroutine(PrintSentences());
        

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

    private IEnumerator PrintSentences()
    {
        foreach (var sentence in _sentenceList)
        {
            foreach (var t in sentence)
            {
                yield return new WaitForSeconds(waitBetweenLetters);
                textArea.text += t;
            }

            yield return new WaitForSeconds(waitBetweenSentences);
            
            textArea.text = "";

        }
        loadNextLevel.NextLevel();
        
    }
    
}
