using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerNextLvl : MonoBehaviour
{
    [SerializeField] private ControlWordsProlog controls;
    [SerializeField] private GameObject gameObject;
    // Start is called before the first frame update
    private void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    private void Update()
    {
        if (controls.activateNextLevelTrigger)
        {
            gameObject.SetActive(true);
        }
    }
}
