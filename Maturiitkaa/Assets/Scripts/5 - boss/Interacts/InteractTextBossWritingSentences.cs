using System;
using TMPro;
using Unity.VisualScripting;
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

    private const float SmallBubble = 2.3f;
    private const float MediumBubble = 4.5f;
    private const float BigBubble = 7f;


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
            writeOutSentences.rowIndex++;
            interactable = false;
            writing.UseDefaultTextArea();
            
            
            
            if (writeOutSentences.nextGameObject.IsUnityNull()) // for if Milan text is next
            {
                writeOutSentences.screenController.MoveUp(2);
                return;
            }
            
            var scrollSize=0f;
            
            switch (writeOutSentences.ReturnNumOfLinesNextObject())
            {
                case 1:
                    scrollSize = SmallBubble;
                    break;
                case 2:
                    scrollSize = MediumBubble;
                    break;
                case 3:
                    scrollSize = BigBubble;
                    break;
                default:
                    scrollSize = 0;
                    break;
            } 
            
            writeOutSentences.screenController.MoveUp(scrollSize);
            writing.controlWordsBoss.milanDoneWriting = true;
            writing.controlWordsBoss.milanWritingIndex++;
            writing.controlWordsBoss.objectQuery++;
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
