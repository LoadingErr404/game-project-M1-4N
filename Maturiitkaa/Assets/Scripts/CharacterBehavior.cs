using System;
using UnityEngine;

public class CharacterBehavior : MonoBehaviour
{
    public Animator animator;

    public CharacterController2D characterController2D;
    private readonly String _move = "Move";
    private readonly String _jump = "Jump";
    private readonly String _canJump = "CanJump";
    private double _currentTime;
    private readonly double _resetAnimationTime = 2;
    public float motionTime;

    private void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        _currentTime += Time.deltaTime;
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
        
        
            if ((characterController2D.moveLeft || characterController2D.moveRight) && characterController2D.isGrounded)
            {
                animator.SetBool(_move, true);

            }
            else
            {
                animator.SetBool(_move, false);
            }

            if (Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W)&& Input.GetKeyDown(KeyCode.LeftShift)))
            {
                animator.SetTrigger(_jump);

                //animator.SetBool(_jump, !(characterController2D.isGrounded));
                /*if (_currentTime <= _resetAnimationTime)
                {
                    animator.Play("Jump_animation");
                }
                else
                {
                    _currentTime = 0.0;
                }*/

            }
            else
            {
                //animator.ResetTrigger(_jump);
            }
            
    }

    
    
    
}
