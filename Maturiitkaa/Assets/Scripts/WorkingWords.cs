using System;
using System.Collections.Generic;
using UnityEngine;
public class WorkingWords : MonoBehaviour
{
    [SerializeField] private TextAsset myFile;
    private readonly List<Word> _wordsList = new();
    [SerializeField] private string separatorParts;
    
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
