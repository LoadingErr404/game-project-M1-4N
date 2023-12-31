using System;
using UnityEngine;

public class CameraMoveFollow : MonoBehaviour
{
    public CharacterController2D character;
    [Header("Camera offset")]
    [SerializeField] private float offX;
    [SerializeField] private float offY;
    [SerializeField] private float offZ;
    private Vector3 _offset;

    [Header("Zooming")] 
    [SerializeField] private Transform zoomOutPoint; //object from scene
    [SerializeField] private Transform zoomInPoint;
    [SerializeField] private Transform midPoint;
    [SerializeField] private float zoomSpeed;
    [SerializeField] private Camera cam;

    [Header("Zooming settings")] 
    [SerializeField] private float maxZoomSize;
    [SerializeField] private float minZoomSize;
    [SerializeField] private float defaultZoomSize;
    
    private static float _zoomOutPoint;  //for saving position from scene only once
    private static float _zoomInPoint;
    private static float _midPoint;
    private float _distanceZoomOut;
    private float _distanceZoomIn;
    private float _startSize;
    private float _endSize;

    //private const float SmoothTime = 0f; //how long it takes to catch up

    private Vector3 _velocity = Vector3.zero;

    [SerializeField] Transform target;
    private float _diff;

    private void Start()
    {
        _zoomInPoint = zoomInPoint.position.x;
        _zoomOutPoint = zoomOutPoint.position.x;
        _midPoint = midPoint.position.x;
        cam.orthographicSize = defaultZoomSize;
        target = character.transform;
    }


    // Update is called once per frame
    void Update()
    { 
        
        MoveCam();
        ZoomCam();

    }

    private void MoveCam()
    {
        
        //_diff = myPosition.y - tarPosition.y;
        if (!character.isGrounded)
        {
            _offset = new Vector3(offX, _diff, offZ);
        }
        _offset = new Vector3(offX, offY, offZ); //the cam doesn't move on the Y axis
        Vector3 targetPosition = target.position + _offset;
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _velocity, 0);
    }

    private void Zoom()
    {
        var newCamSize = 0f;
        if ((target.position.x - _midPoint) < 0)
        { 
            
           newCamSize = Remap((target.position.x - _zoomOutPoint), 0, Math.Abs(_midPoint - _zoomOutPoint), maxZoomSize, defaultZoomSize);
           if (newCamSize > maxZoomSize) return;
           
        }
        else
        {
            newCamSize = Remap((_zoomInPoint - target.position.x), 0, Math.Abs(_zoomOutPoint - _midPoint), minZoomSize, defaultZoomSize - 2)+1;
            if(newCamSize < (minZoomSize+1)) return;
        }
        Debug.Log(newCamSize);
        cam.orthographicSize = Mathf.SmoothStep(cam.orthographicSize, newCamSize, 0.2f);
        
    }

    private void ZoomCam()
    {
        var targetX = target.position.x;
        var newCamSize = 0f;
        var distanceOut = targetX - _zoomOutPoint;
        var distanceIn = _zoomInPoint - targetX;

        if (distanceOut < distanceIn)
        {
            newCamSize = Remap((target.position.x - _zoomOutPoint), 0, Math.Abs(_midPoint - _zoomOutPoint), maxZoomSize, defaultZoomSize);
            if (newCamSize > maxZoomSize) return;
        }
        else
        {
            newCamSize = Remap((_zoomInPoint - target.position.x), 0, Math.Abs(_zoomOutPoint - _midPoint), minZoomSize, defaultZoomSize - 2)+1;
            if(newCamSize < (minZoomSize+1)) return;
        }
        
        Debug.Log(newCamSize);
        cam.orthographicSize = Mathf.SmoothStep(cam.orthographicSize, newCamSize, 0.2f);
    }
    private static float Remap (float value, float from1, float from2, float to1, float to2)
    {
        return to1 + (value-from1)*(to2-to1)/(from2-from1);
    }
    
}
