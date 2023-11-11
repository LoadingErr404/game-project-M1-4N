using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterBehavior : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D characterController2D;
    private readonly String _move = "Move";
    private readonly String _jump = "Jump";
    
    
    // Update is called once per frame
    void Update()
    {
        
        AnimationGoIdleJump();
        
        if (characterController2D.moveLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //changes localScale to make character look left
        }
        if (characterController2D.moveRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); //changes localScale to make character look right
        }
        
       
    }
    

    private void AnimationGoIdleJump() //handles animation switches between go, idle and jump
    {
        
            if (characterController2D.moveLeft || characterController2D.moveRight)
            {
                animator.SetBool(_move, true);
                
            }
            else
            {
                animator.SetBool(_move, false);
            }

            if (characterController2D.moveUp)
            {
                animator.SetBool(_jump, !(characterController2D.isGrounded));
            }
            else
            {
                animator.SetBool(_jump, false);
            }
            
        
        

        
        
        
    }
}
