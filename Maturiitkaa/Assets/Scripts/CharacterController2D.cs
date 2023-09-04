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

    private void Awake()
    {
        throw new NotImplementedException();
        _rigidbody2D = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        float moveX = 0f;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            //transform.position += new Vector3(-1, 0);
            moveX -= movementForce;

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            //transform.position += new Vector3(1, 0);
            moveX += movementForce;
        }

        moveDir = new Vector3(moveX, 0);
    }

    private void FixedUpdate() //for physics
    {
        throw new NotImplementedException();
        _rigidbody2D.velocity = moveDir;
    }
}
