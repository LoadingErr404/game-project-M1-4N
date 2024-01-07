using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [FormerlySerializedAs("_movementForce")]
    [Header("Movement physics")]
    [SerializeField] private float movementForce;
    [SerializeField] private float jumpForce;
    private Vector3 _moveDir; //vector that will be handeling physics
    private Vector3 _moveJump; //vector that will be handeling jumping physics
    
    
    [Header("Movement bools")] //must be public for CharacterBehavior
    public bool moveUp;
    public bool notMoveUp;
    public bool moveLeft;
    public bool moveRight;
    private bool _moveUpKeyDown;


    [Header("Jump motion settings")] 
    [SerializeField] private float jumpCooldown;
    public bool ableToJump; //redudnant but needed for CharacterBehavior
    [SerializeField] private MyTimer myTimerJumpCooldown;
    [SerializeField] private MyTimer myTimerSaveJump;
    
    //for ground check
    public bool isGrounded;
    [SerializeField] private Transform feetPosition; //possition of player's feet
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask layerOfGround; //will be checking for Tag "ground"
    
    
    [Header("Settings for buffered jump")]
    private float _jumpTimeCounter;
    [SerializeField] private float jumpTime;
    private bool _isJumping;
    private int _jumps;
    
    

    private void Start()
    {
        isGrounded = false;
        _isJumping = false;
        ableToJump = true;
        _jumps = 0;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        myTimerJumpCooldown.timerDelayTrigger = jumpCooldown; //making the max time value according to our value
        myTimerSaveJump.timerDelayTrigger = 0.5;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //cannot move to Start - isn't working there
    }

    // Update is called once per frame
    void Update()
    {
        LoadInputs();
        
      // Debug.Log(IsAbleToJumpAgain());
        MovingAround();
        //IsAbleToJump();
        
        
        


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
        _moveUpKeyDown = Input.GetKeyDown(KeyCode.UpArrow) || ((Input.GetKeyDown(KeyCode.W) && Input.GetKey(KeyCode.LeftShift))); //shift needs to be GetKey because you press it down before W
        
    }

    private void MovingAround()
    {
       
        if (moveLeft || moveRight)
        {
            _moveDir = new Vector3(movementForce * Input.GetAxisRaw("Horizontal"),
                _rigidbody2D.velocity.y); //moving left-right

        }

        isGrounded =
            Physics2D.OverlapCircle(feetPosition.position, checkRadius,
                layerOfGround); //checks if the overlaped circle that is located at characters feet is touching "ground"
        
        if (isGrounded && moveUp) //will jump if we are on ground and press up arrow
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rigidbody2D.velocity = Vector2.up * jumpForce;
            ableToJump = true;
        }

        if (_isJumping && canJumpAgain())
        {
            Debug.Log(("eyeye"));
        }
       

        if (moveUp && _isJumping) //buffered jump
        {
            if (_jumpTimeCounter > 0)
            {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
                
            }
            
        }
        else
        {
            _isJumping = false;
        }
            
    }
    

    private bool canJumpAgain()
    {
        bool jumpAgain = !_moveUpKeyDown || notMoveUp;

        if (!isGrounded)
        {
            jumpAgain = false;
        }

        return jumpAgain;
    }
    
    
}