using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using Unity.VisualScripting;
using UnityEditor;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class WorkingWords : MonoBehaviour
{
    [SerializeField] private TextAsset myFile;
    private readonly List<Word> _wordsList = new();
    [SerializeField] private string separatorParts;
    
    // Start is called before the first frame update
    private void Start()
    {
        LoadWords();
   
    }


    private void LoadWords()
    {
        try
        { 
            
            var textFromFile = myFile.ToString(); //gets contents of file
            var lines = textFromFile.Split(Environment.NewLine.ToCharArray());
            
            
            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    continue;
                }
                
                var arr= line.Split(separatorParts);
                _wordsList.Add(new Word(arr[0], int.Parse(arr[1])));
                
            }
            

        }
        catch (Exception e)
        {
            Debug.Log(e);
        }
    }

    public List<Word> ListOfWords()
    {
        return _wordsList;
    }
}
