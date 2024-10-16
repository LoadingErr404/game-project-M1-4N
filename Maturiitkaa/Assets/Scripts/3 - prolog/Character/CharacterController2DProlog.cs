using UnityEngine;
using UnityEngine.Serialization;

public class CharacterController2DProlog : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    [SerializeField] public ControlWordsProlog controlWordsProlog;
    
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
    public bool ableToJump;
    
    //for ground check
    public bool isGrounded;
    [SerializeField] private Transform feetPosition; //possition of player's feet
    [SerializeField] private float checkRadius;
    [SerializeField] private LayerMask layerOfGround; //will be checking for Tag "ground"
    
    
    [Header("Settings for buffered jump")]
    private float _jumpTimeCounter;
    [SerializeField] private float jumpTime;
    private bool _isJumping;
    private bool _doneJumping;
    
    private void Start()
    {
        isGrounded = false;
        _isJumping = false;
        ableToJump = true;
        _doneJumping = false;
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        controlWordsProlog.canMove = true;

    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>(); //cannot move to Start - isn't working there
    }

    // Update is called once per frame
    private void Update()
    {
        
        
        if (!controlWordsProlog.canMove)
        {
            _moveDir = new Vector3(0, 0, 0);
            moveRight = false;
            moveLeft = false;
            moveUp = false;
            return;
        }
        
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

        if (_doneJumping && CanJumpAgain())
        {
            return;
        }
        
    
        if (isGrounded && moveUp) //will jump if we are on ground and press up arrow
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rigidbody2D.velocity = Vector2.up * jumpForce;
            ableToJump = true;
        }
        
       

        if (moveUp && _isJumping) //buffered jump
        {
            if (_jumpTimeCounter > 0)
            {
                _rigidbody2D.velocity = Vector2.up * jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
                _doneJumping = false;
            }
            else
            {
                _doneJumping = true;
            }
            
        }
        else
        {
            _isJumping = false;
            _doneJumping = true;
        }
            
    }
    

    private bool CanJumpAgain()
    { 
        var jump = !_moveUpKeyDown || notMoveUp;
        return jump;
    }

    public ControlWordsProlog getControlWordsProlog()
    {
        return controlWordsProlog;
    }
    
}