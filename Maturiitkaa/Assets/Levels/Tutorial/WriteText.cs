using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WriteText : MonoBehaviour
{
    [SerializeField] private string givenWord;
    [SerializeField] private TMP_Text textArea;
    private bool _writeOut;
    [SerializeField] private float writeOutDelay;
    private float _writeCounter;
    private int _position;
    [SerializeField] private SpriteRenderer image;
    private Color _color;
    private bool _fadeIn;


    private void Start()
    {//sets alpha to 0
        _color = image.material.color;
        _color.a = 0f;
        image.material.color = _color;
    }

    private void Update()
    {
        if (!_writeOut)
        {
            return;
        }

        if (_writeCounter < writeOutDelay)
        {
            _writeCounter += Time.deltaTime;
            return;
        }
        
        if (_position >= givenWord.Length)
        {
            return;
        }
            
        _writeCounter = 0f;
        textArea.text += givenWord[_position++];
        
        



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        _writeOut = true;
        if (_fadeIn)
        {
            return;
        }
        
        StartCoroutine("FadeIn");
    }

    private IEnumerator FadeIn() //coroutine
    {
        _fadeIn = true;
        for (var f = 0.05f; f <= 1; f += 0.05f)
        {
            _color = image.material.color;
            _color.a = f;
            image.material.color = _color;
            yield return new WaitForSeconds(0.05f);
        }
    }
}
