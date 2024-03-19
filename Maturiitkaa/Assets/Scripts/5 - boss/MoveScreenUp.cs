using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class MoveScreenUp : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    public ControlWordsBoss controls;
    private Vector3 _velocity = Vector3.zero;

    private void Start()
    {
        controls.milanDoneWriting = true;
        
    }


    public void MoveUp(float valueUp)
    {
        var position = canvas.transform.position;
        var targetPosition = new Vector3(position.x, position.y + valueUp, position.z);
        
        position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, 0);
        canvas.transform.position = position;
    }
}
