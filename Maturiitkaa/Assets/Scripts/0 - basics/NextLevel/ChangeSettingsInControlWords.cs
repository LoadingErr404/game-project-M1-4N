using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSettingsInControlWords : MonoBehaviour
{
    [SerializeField] private WritingGameplayProlog writing;

    private void OnTriggerEnter2D(Collider2D other)
    {
        writing.controlWordsProlog.activateNextLevelTrigger = true;
    }
}
