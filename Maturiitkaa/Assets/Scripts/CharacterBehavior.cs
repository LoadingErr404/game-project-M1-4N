using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterBehavior : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D characterController2D;
    
    public bool isGrounded;
    //fuckupujou to feetz idk proč ale
    public Transform feetPossition; //possition of player's feet
    public float checkRadius;
    public LayerMask layerOfGround; //will be checking for Tag "ground"
   
    
    

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPossition.position, checkRadius, layerOfGround); //checks if the overlaped circle that is located at characters feet is touching "ground"
        AnimationGoIdleJump(characterController2D, animator);
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //changes localScale to make character look left
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.eulerAngles = new Vector3(0, 180, 0); //changes localScale to make character look right
        }
        
       
    }
    

    private void AnimationGoIdleJump(CharacterController2D ch2D, Animator ani) //handles animation switches between go, idle and jump
    {
        
            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))
            {
                ani.SetBool("Move", true);
                
            }
            else
            {
                ani.SetBool("Move", false);
            }

            if (Input.GetKey(KeyCode.UpArrow))
            {
                ani.SetBool("Jump", !(ch2D.isGrounded));
            }
            else
            {
                ani.SetBool("Jump", false);
            }
            
        
        

        
        
        
    }
}
