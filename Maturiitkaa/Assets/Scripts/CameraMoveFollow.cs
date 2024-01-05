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
    [SerializeField] private Camera cam;

    [Header("Zooming settings")] 
    [SerializeField] private float maxZoomSize;
    [SerializeField] private float minZoomSize;
    [SerializeField] private float defaultZoomSize;
    
    [Header("Offset settings")] 
    [SerializeField] private float bottomOffset;
    [SerializeField] private float topOffset;
    
    
    private static float _zoomOutPoint;  //for saving position from scene only once
    private static float _zoomInPoint;
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
    

    private void ZoomCam()
    {
        var targetX = target.position.x;
        var newCamSize = 0f;
        var distanceOut = targetX - _zoomOutPoint;
        var distanceIn = _zoomInPoint - targetX;
        var distanceOutIn = _zoomInPoint - _zoomOutPoint;
        var newOffset = 0f;

        newCamSize = Remap((distanceOut), 0, Math.Abs(distanceOutIn), maxZoomSize, minZoomSize);

        if (newCamSize > maxZoomSize || newCamSize < minZoomSize) return; //out of bounds

        newOffset = Remap(newCamSize, minZoomSize, maxZoomSize, topOffset, bottomOffset); //otestovat
        cam.transform.position.y = newOffset; //otestovat
        
        Debug.Log(newCamSize);
        cam.orthographicSize = Mathf.SmoothStep(cam.orthographicSize, newCamSize, 0.2f);
    }
    private static float Remap (float value, float from1, float from2, float to1, float to2)
    {
        return to1 + (value-from1)*(to2-to1)/(from2-from1);
    }
    
}
