using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [Header("Movement physics")]
    public float movementForce;
    public float jumpForce;

    private Vector3 moveDir; //vector that will be handeling physics
    private Vector3 moveJump; //vector that will be handeling jumping physics
    
    //for jumping
    private bool isGrounded;
    public Transform feetPossition; //possition of player's feet
    public float checkRadius;
    public LayerMask layerOfGround; //will be checking for Tag "ground"
    

    private void Start()
    {
        _rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        moveDir = new Vector3(movementForce * Input.GetAxisRaw("Horizontal"), _rigidbody2D.velocity.y); //moving left-right
        isGrounded = Physics2D.OverlapCircle(feetPossition.position, checkRadius, layerOfGround); //checks if the overlaped circle that is located at characters feet is touching "ground"

        if (isGrounded && Input.GetKey(KeyCode.UpArrow)) //will jump if we are on ground and press up arrow
        {
            _rigidbody2D.velocity = Vector2.up * jumpForce;
        }
        
    }

    private void FixedUpdate() //for physics
    {
        _rigidbody2D.velocity = moveDir; //moving left-right
    }
    
}