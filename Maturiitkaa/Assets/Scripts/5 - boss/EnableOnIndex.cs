using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnableOnIndex : MonoBehaviour
{
    [SerializeField] private ControlWordsBoss controls;
    [SerializeField] private GameObject myObject;
    [SerializeField] private int index;
    
    private void Start()
    {
        myObject.SetActive(false);
    }
    
    private void Update()
    {
        if (controls.objectQuery == index)
        {
            myObject.SetActive(true);
        }
    }
}
