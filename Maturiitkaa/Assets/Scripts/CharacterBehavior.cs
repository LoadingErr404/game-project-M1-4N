using System;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] CharacterController2D characterController2D;
    private readonly String _move = "Move";
    private readonly String _jump = "Jump";
    

    // Update is called once per frame
    void Update()
    {
        MoveLeftRight();
        AnimationGoIdleJump();
        
      
    }
    

    private void AnimationGoIdleJump() //handles animation switches between go, idle and jump
    {
        
        
            if ((characterController2D.moveLeft || characterController2D.moveRight) && characterController2D.isGrounded)
            {
                animator.SetBool(_move, true);

            }
            else
            {
                animator.SetBool(_move, false);
            }

            if ((Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))) && characterController2D.ableToJump) //cannot use GetKey -> leads to looping
            {
                animator.SetTrigger(_jump);
            }
    }

    private void MoveLeftRight()
    {
        if (characterController2D.moveLeft)
        {
            transform.eulerAngles = new Vector3(0, 0, 0); //changes localScale to make character look left
        }
        if (characterController2D.moveRight)
        {
            transform.eulerAngles = new Vector3(0, 180, 0); //changes localScale to make character look right
        }  
    }
    
    
}
