using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInPicture : MonoBehaviour
{
    
    [SerializeField] private SpriteRenderer image;
    private Color _color;
    private bool _fadeIn;
    
   
    private void Start()
    {//sets alpha to 0
        _color = image.material.color;
        _color.a = 0f;
        image.material.color = _color;
    }

   

    private void OnTriggerEnter2D(Collider2D other)
    { 
        
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
