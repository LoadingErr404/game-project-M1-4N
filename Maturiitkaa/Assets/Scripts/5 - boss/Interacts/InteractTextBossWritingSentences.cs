using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class InteractTextBossWritingSentences : MonoBehaviour
{
    [SerializeField] public string textForInteraction;
    [SerializeField] private WritingGameplayBoss writing;
    [SerializeField] private WriteOutSentencesBoss writeOutSentences;
    [SerializeField] private TMP_Text textArea;
    public bool interactable;
    
    private enum ReturnMeanings {EmptyWord, NotMatchingLetter, MatchingLetter};
    
    
    private void Update()
    {

        if (!interactable)
        {
            return;
        }
        
        
        if (!writeOutSentences.ableToWriteInto)
        {
            return;
        }
        
        
        
        var result = CheckIndexes(writing.ReturnText());
        
        switch (result)
        {
            case (int)ReturnMeanings.EmptyWord:
                return;
            case (int)ReturnMeanings.NotMatchingLetter:
                writing.ClearText();
                break;
        }
        
        if (writing.ReturnText().Equals(textForInteraction))
        {
            writing.ClearText();
            writeOutSentences.writeNewSentence = true;
            writeOutSentences.rowIndex++;
            textArea.text = "";
        }
        
    }
    

    private int CheckIndexes(string textFromField)
    {
        if (textFromField.Length == 0)
        {
            return (int) ReturnMeanings.EmptyWord;
        }
        
        if (textFromField.Length > textForInteraction.Length)
        {
            return (int)ReturnMeanings.NotMatchingLetter;
        }
        
        for (var i = 0; i < textFromField.Length; i++)
        {
            if (textFromField[i] != textForInteraction[i])
            {
                return (int)ReturnMeanings.NotMatchingLetter;
            }
        }
        
        return (int)ReturnMeanings.MatchingLetter;
    }
}
