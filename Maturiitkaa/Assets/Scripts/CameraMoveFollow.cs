using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraMoveFollow : MonoBehaviour
{
    public float offX;
    public float offY;
    public float offZ;
    private Vector3 _offset;

    private const float SmoothTime = 0f; //how long it takes to catch up

    private Vector3 _velocity = Vector3.zero;

    public Transform target;
    private float _diff;

    private void Start()
    {
        //_offset = new Vector3(offX, offY, offZ);
    }

    // Update is called once per frame
    void Update()
    {
        //var tarPosition = target.position;
        
        _diff = transform.position.y - target.position.y;
        _offset = new Vector3(offX, _diff, offZ); //the cam doesn't move on the Y axis
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, SmoothTime); //function that makes smooth camera move
    }
}
