using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody2D;
    
    [Header("Movement physics")]
    public float movementForce;

    private Vector3 moveDir; //vector that will be handeling physics

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
        moveDir = new Vector3(movementForce * Input.GetAxisRaw("Horizontal"), _rigidbody2D.velocity.y);
    }

    private void FixedUpdate() //for physics
    {
        _rigidbody2D.velocity = moveDir;
    }
    
}