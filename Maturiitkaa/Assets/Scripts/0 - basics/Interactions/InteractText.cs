using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class InteractText : MonoBehaviour
{
    public UnityEvent successfulInteraction;
    [SerializeField] private string textForInteraction;
    [SerializeField] private TMP_Text ownTextField;
    [SerializeField] private TMP_Text stableWordText;
    [SerializeField] private WritingGameplay writing;
    private bool _ableToWriteInto; //for not twice into interaction event
    private bool _interactable;
    private enum ReturnMeanings {EmptyWord, NotMatchingWord, MatchingWord};
    

    private void Start()
    {
        stableWordText.text = textForInteraction;
        _ableToWriteInto = true;
        _interactable = false;
        successfulInteraction.AddListener(GameObject.FindWithTag("destroyRocks").GetComponent<DestroyObject>().DestroySelf);
    }

    private void Update()
    {

        if (!_interactable)
        {
            return;
        }
        
        if (!_ableToWriteInto)
        {
            return;
        }
        
        if (writing.ReturnText().Equals(textForInteraction))
        {
            successfulInteraction.Invoke();
            Destroy(ownTextField);
            Destroy(stableWordText);
            Destroy(gameObject);
            return;
        }
        
        var result = CheckIndexes(writing.ReturnText());
        
        if (result == (int) ReturnMeanings.NotMatchingWord)
        {
            writing.ClearText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _interactable = true;
        writing.controlWordsTutorial.stopWritingTimer = true;
        writing.ChangeTextArea(ownTextField);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        _interactable = false;
        writing.controlWordsTutorial.stopWritingTimer = false;
        writing.UseDefaultTextArea();
        
    }

    private int CheckIndexes(string textFromField)
    {
        if (textFromField.Length == 0)
        {
            return (int) ReturnMeanings.EmptyWord;
        }
        
        if (textFromField.Length > textForInteraction.Length)
        {
            return (int)ReturnMeanings.NotMatchingWord;
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
