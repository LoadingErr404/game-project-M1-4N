using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [Header("Movement physics")]
    public float movementForce;
    public float jumpForce;

    private Vector3 _moveDir; //vector that will be handeling physics
    private Vector3 _moveJump; //vector that will be handeling jumping physics
    [Header("Movement bools")]
    public bool moveUp;
    public bool notMoveUp;
    public bool moveLeft;
    public bool moveRight;


    [Header("Jump motion settings")] 
    public float jumpCooldown;
    public bool ableToJump; //redudnant but needed for CharacterBehavior
    public MyTimer myTimer;
    private bool _jumpAgain;
    
    private double _currentTime;
    public bool isGrounded;
    public Transform feetPossition; //possition of player's feet
    public float checkRadius;
    public LayerMask layerOfGround; //will be checking for Tag "ground"
    [Header("Settings for buffered jump")]
    private float _jumpTimeCounter;
    public float jumpTime;
    private bool _isJumping;
    
    

    private void Start()
    {
        isGrounded = false;
        _isJumping = false;
        ableToJump = true;
        _jumpAgain = true;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        myTimer.timerDelayTrigger = jumpCooldown; //making the max time value according to our value
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //cannot move to Start - isn't working there
    }

    // Update is called once per frame
    void Update()
    {
        LoadInputs();
        MovingAround();
        


    }

    private void FixedUpdate() //for physics
    {
        if (moveLeft || moveRight)
        {
            _rigidbody2D.velocity = _moveDir; //moving left-right
        }
    }

    private void LoadInputs()
    {
        moveUp = Input.GetKey(KeyCode.UpArrow) || ((Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.LeftShift)));
        notMoveUp = Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.W);
        moveLeft = Input.GetKey(KeyCode.LeftArrow) || (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.LeftShift));
        moveRight = Input.GetKey(KeyCode.RightArrow) || (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.LeftShift));
    }

    private void MovingAround()
    {
       
        if (moveLeft || moveRight)
        {
            _moveDir = new Vector3(movementForce * Input.GetAxisRaw("Horizontal"),
                _rigidbody2D.velocity.y); //moving left-right

        }

        isGrounded =
            Physics2D.OverlapCircle(feetPossition.position, checkRadius,
                layerOfGround); //checks if the overlaped circle that is located at characters feet is touching "ground"

        AbleToJumpAgain();
        IsAbleToJump();
        
        if (!ableToJump)
        {
            return;
        }
        

        if (isGrounded && moveUp) //will jump if we are on ground and press up arrow
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rigidbody2D.velocity = Vector2.up * jumpForce;
        }

        if (moveUp && _isJumping) //buffered jump
        {
            if (_jumpTimeCounter > 0)
            {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
                ableToJump = false;
            }

        }

    }

    private void IsAbleToJump()
    {
        if (!isGrounded)
        {
            return;
        }
        
       
        if (myTimer.currentTime >= myTimer.timerDelayTrigger){
            myTimer.currentTime = 0.0;
            ableToJump = true;
        }
        
    }

    private void AbleToJumpAgain()
    {
        if (moveUp)
        {
           _jumpAgain = false;
        }

       // _jumpAgain = !moveUp; <- todle je ten problem
        if (!moveUp)
        {
            _jumpAgain = true;
        }

        if (notMoveUp)
        {
            _jumpAgain = true;
        }
        
    }
    
}