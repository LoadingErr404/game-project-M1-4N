using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class WriteIntoBubble : MonoBehaviour
{
    [SerializeField] private int queryIndex;
    [SerializeField] private WritingGameplayBoss writing;
    [SerializeField] private ControlWordsBoss controls;
    [SerializeField] private TMP_Text textArea;
    [SerializeField] private TextAsset file;
    [SerializeField] private ManagingWords managingWords;
    [SerializeField] private WorkingWords workingWords;
    [SerializeField] private DadWriteOuts nextObject;
    [SerializeField] private MoveScreenUp screenController;
    private readonly List<string> _wordsList = new();
    private int _sizeOfLongest;
    private bool _interactable;
    private const float SmallBubble = 2.2f;
    private const float MediumBubble = 4.7f;
    private const float BigBubble = 5.2f;

    private void Start()
    {
        LoadWords();
        StartCoroutine(InitSetup());
        _sizeOfLongest = managingWords.ReturnLenghtLongest(_wordsList);
        
        
    }

    private void Update()
    {
        if (!_interactable)
        {
            return;
        }

        controls.milanDoneWriting = false;
        controls.showInteractInterface = true;

        if (textArea.text.Length > _sizeOfLongest)
        {
            writing.ClearText();
            return;
        }
        
        foreach (var listWord in workingWords.ListOfWords())
        {
            if (listWord.MyWord.Equals(textArea.text))
            {
                controls.dadHp -= listWord.Damage;
                _interactable = false;
                writing.UseDefaultTextArea();
                controls.objectQuery++;
                managingWords.ClearTexts();
                controls.showInteractInterface = false;
                controls.milanWritingIndex++;
                controls.milanDoneWriting = true;
                Move();
            }
        }
    }
    
    private void LoadWords()
    {
        var textFromFile = file.ToString(); //gets contents of file
        var lines = textFromFile.Split(Environment.NewLine.ToCharArray());

        foreach (var line in lines)
        {
            if (!line.Equals(""))
            {
                _wordsList.Add(line);
            }
            
        }

    }

    private IEnumerator InitSetup()
    {
        yield return new WaitUntil(MyTurn);
        managingWords.SetTexts(_wordsList);
        writing.ChangeTextArea(textArea);
        _interactable = true;

    }

    private bool MyTurn()
    {
        return controls.objectQuery == queryIndex;
    }

    private void Move()
    {
        if (nextObject.IsUnityNull()) // for if Milan text is next
        {
            screenController.MoveUp(1.8f);
            return;
        }
            
        var scrollSize=0f;
            
        switch (nextObject.numberOfLines)
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
            
        screenController.MoveUp(scrollSize);
    }
    

}
