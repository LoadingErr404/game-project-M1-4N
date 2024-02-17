using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private int offY;
    [SerializeField] private int offX;
    private Vector3 _velocity;
    
    private void Update()
    {
        var position = target.transform.position;
        var targetPosition = new Vector3(position.x + offX, position.y + offY, position.z);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, 0);
    }
    
}
