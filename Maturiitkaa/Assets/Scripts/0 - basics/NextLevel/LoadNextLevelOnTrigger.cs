using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadNextLevelOnTrigger : MonoBehaviour
{
    [SerializeField] public WritingGameplayProlog writing;
   

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!writing.controlWordsProlog.activateNextLevelTrigger)
        {
            return;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
