using UnityEngine;

public class CharacterBehaviorProlog : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private CharacterController2DProlog characterController2D;
    private const string Move = "Move";
    private const string Jump = "Jump";

    private void Update()
    {
        MoveLeftRight();
        AnimationGoIdleJump();
    }
    
    private void AnimationGoIdleJump() //handles animation switches between go, idle and jump
    {
        
        
            if ((characterController2D.moveLeft || characterController2D.moveRight) && characterController2D.isGrounded)
            {
                animator.SetBool(Move, true);

            }
            else
            {
                animator.SetBool(Move, false);
            }

            if ((Input.GetKeyDown(KeyCode.UpArrow) || (Input.GetKeyDown(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))) && characterController2D.ableToJump) //cannot use GetKey -> leads to looping
            {
                animator.SetTrigger(Jump);
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
