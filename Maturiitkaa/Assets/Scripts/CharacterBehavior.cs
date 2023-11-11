using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterBehavior : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D characterController2D;
    private String move = "Move";
    private String jump = "Jump";
    
    // Update is called once per frame
    void Update()
    {
        AnimationGoIdleJump();
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //changes localScale to make character look left
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0); //changes localScale to make character look right
        }
        
       
    }
    

    private void AnimationGoIdleJump() //handles animation switches between go, idle and jump
    {
        
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                animator.SetBool(move, true);
                
            }
            else
            {
                animator.SetBool(move, false);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                animator.SetBool(jump, !(characterController2D.isGrounded));
            }
            else
            {
                animator.SetBool(jump, false);
            }
            
        
        

        
        
        
    }
}
