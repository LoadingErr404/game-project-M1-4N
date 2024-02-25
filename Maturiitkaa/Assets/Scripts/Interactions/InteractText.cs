using System;
using TMPro;
using UnityEngine;

public class InteractText : MonoBehaviour
{

    [SerializeField] private string textForInteraction;
    [SerializeField] private TMP_Text ownTextField;
    [SerializeField] private TMP_Text stableWordText;
    [SerializeField] private WritingGameplay writing;
    private enum ReturnMeanings {EmptyWord, NotMatchingWord, MatchingWord};

    private void Start()
    {
        stableWordText.text = textForInteraction;
    }

    private void Update()
    {
        var textFromField = writing.ReturnText();
        if (CheckIndexes(textFromField) == (int) ReturnMeanings.NotMatchingWord)
        {
            writing.ClearText();
        }
       
        
        if (textFromField.Equals(textForInteraction))
        {
            writing.controlWordsTutorial.successWritingWord = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        writing.controlWordsTutorial.stopWritingTimer = true;
        writing.ChangeTextArea(ownTextField);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        writing.controlWordsTutorial.stopWritingTimer = false;
        writing.UseDefaultTextArea();
    }

    private int CheckIndexes(string textFromField)
    {
        if (textFromField == null)
        {
            return (int) ReturnMeanings.EmptyWord;
        }
        
        for (var i = 0; i < textFromField.Length; i++)
        {
            if (textFromField[i] != textForInteraction[i])
            {
                return (int)ReturnMeanings.NotMatchingWord;
            }
        }

        return (int)ReturnMeanings.MatchingWord;
    }
}
