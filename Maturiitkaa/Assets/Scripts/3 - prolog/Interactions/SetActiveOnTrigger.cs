using System;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class SetActiveOnTrigger : MonoBehaviour
{
    [SerializeField] private GameObject toSetActive;
    private void Start()
    {
        toSetActive.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        toSetActive.SetActive(true);
        
       
    }
   
}
