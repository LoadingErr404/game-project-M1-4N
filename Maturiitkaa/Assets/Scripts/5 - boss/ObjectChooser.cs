using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectChooser : MonoBehaviour
{

    [SerializeField] private ControlWordsBoss controls;
    [SerializeField] private GameObject winObject;
    [SerializeField] private GameObject looseObject;
    
    // Start is called before the first frame update
    private void Start()
    {
        winObject.SetActive(false);
        looseObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        winObject.SetActive(controls.dadHp <= 0);
        looseObject.SetActive(controls.dadHp > 0);
    }
}
