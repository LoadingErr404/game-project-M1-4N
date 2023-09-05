using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Animator animator;

    //private static readonly int Move = Animator.StringToHash("Move");

    // Start is called before the first frame update
    void Start()
    {
        //controls animation for movement
        
        
        
    }

    // Update is called once per frame
    void Update()
    {
        AnimationGoIdle();
    }

    private void AnimationGoIdle() //handles animation switches between go and idle
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            animator.SetBool("Move", true);
            
        }
        else if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            animator.SetBool("Move", false);
        }
    }
}
