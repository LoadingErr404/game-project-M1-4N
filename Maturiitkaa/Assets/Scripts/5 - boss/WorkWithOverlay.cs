using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkWithOverlay : MonoBehaviour
{
    [SerializeField] private GameObject objectToHide;
    public ControlWordsBoss controls;
    void Start()
    {
        objectToHide.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        
        objectToHide.SetActive(controls.showInteractInterface);
        
        
    }
}
