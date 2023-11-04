using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CharacterBehavior : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D characterController2D;
    
    private bool isGrounded;
    //fuckupujou to feetz idk proč ale
    public Transform feetPossition; //possition of player's feet
    public float checkRadius;
    public LayerMask layerOfGround; //will be checking for Tag "ground"
   
    
    

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(feetPossition.position, checkRadius, layerOfGround); //checks if the overlaped circle that is located at characters feet is touching "ground"
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
                animator.SetBool("Move", true);
            }
            else
            {
                animator.SetBool("Move", false);
            }

/*            if (characterController2D.isGrounded && Input.GetKeyDown(KeyCode.UpArrow))
            {
                while(!(characterController2D.isGrounded)){
                    animator.SetBool("Jump", true);
                }
                animator.SetBool("Jump", false);
            }
            else
            {
                animator.SetBool("Jump", false);
            }*/

        if (characterController2D == null)
        {
            Debug.Log("Nenasel se Character Controler");
        }

        Debug.Log(isGrounded);
        
        

        
        
        
    }
}
