using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using UnityEditor;

using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.Serialization;

public class WorkingWithTextFiles : MonoBehaviour
{
    [SerializeField] private TextAsset myFile;
    private List<Words> _wordsList;
    [SerializeField] private string _seperatorParts;
    [SerializeField] private string _seperatorEndOfLine;
    
    // Start is called before the first frame update
    private void Start()
    {
        try
        { 
            var textFromFile = myFile.ToString(); //gets contents of file
            var numberOfWords = int.Parse(textFromFile.Split("\n")[0]) ; //returns number of words - given in file on first line
            textFromFile = textFromFile.Remove(0,3); //deletes number and /n

            for (var i = 0; i <= numberOfWords; i++)
            {/*
                var word = textFromFile.Split(_seperatorParts)[0]; //gets only the word
                textFromFile = textFromFile.Remove(0, word.Length + 1); //removes the word + separator
                var damage = textFromFile.Split(_seperatorEndOfLine)[0]; //gets only the damage
                textFromFile = textFromFile.Remove(0, damage.Length + 3); //removes the damage + separator + \n
                
                var givenWord = new Words(word, int.Parse(damage));
                
                //_wordsList.Add(new Words(word, int.Parse(damage)));
                //Debug.Log(_wordsList.Count);
                Debug.Log(givenWord.ToString());*/
            }
                
                var word = textFromFile.Split(_seperatorParts)[0]; //gets only the word
                textFromFile = textFromFile.Remove(0, word.Length + 1); //removes the word + separator
                var damage = textFromFile.Split(_seperatorEndOfLine)[0]; //gets only the damage
                textFromFile = textFromFile.Remove(0, damage.Length + 3); //removes the damage + separator + \n
                
                var givenWord = new Words(word, int.Parse(damage));
                
                _wordsList.Add(new Words(word, int.Parse(damage)));
                //Debug.Log(_wordsList.Count);
                Debug.Log(_wordsList.ToString());
            
          
            
            
            
            

        }
        catch (Exception e)
        {
           Debug.Log(e);
        }
       
    }

    
}
