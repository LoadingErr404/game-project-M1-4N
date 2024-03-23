using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SetUpWriteOutSentences : MonoBehaviour
{
    [SerializeField] public WritingGameplayProlog writing;
    [SerializeField] private WriteOutSentences writeOutSentences;
    [SerializeField] private InteractTextPrologWritingSentences interact;
    

    private void Start()
    {
        writing.controlWordsProlog.stopWritingTimer = true;
        writeOutSentences.writeNewSentence = true;
        writeOutSentences.interacting = true;
        writeOutSentences.ableToWriteInto = true;
        interact.interactable = true;
    }

    // Update is called once per frame
    private void Update()
    {
        if (writeOutSentences.rowIndex >= writeOutSentences.ReturnNumOfLines())
        {
            SceneManager.LoadScene("10 - credits");
        }
    }
}
