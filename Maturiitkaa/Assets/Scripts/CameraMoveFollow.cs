using System;
using UnityEngine;

public class CameraMoveFollow : MonoBehaviour
{
    public CharacterController2D character;
    [Header("Camera offset")]
    [SerializeField] float offX;
    [SerializeField] float offY;
    [SerializeField] float offZ;
    private Vector3 _offset;

    [Header("Zooming")] 
    [SerializeField] Transform zoomOutPoint; //object from scene
    [SerializeField] Transform zoomInPoint;
    [SerializeField] float zoomSpeed;
    [SerializeField] Camera cam;
    private float _originZoom;
    private static float _zoomOutPoint;  //for saving position from scene only once
    private static float _zoomInPoint; 
    private float _distanceZoomOut;
    private float _distanceZoomIn;
    private float _zoom;

    private const float SmoothTime = 0f; //how long it takes to catch up

    private Vector3 _velocity = Vector3.zero;

    [SerializeField] Transform target;
    private float _diff;

    private void Start()
    {
        _zoomInPoint = zoomInPoint.position.x;
        _zoomOutPoint = zoomOutPoint.position.x;
        _originZoom = cam.orthographicSize;
        target = character.transform;
    }


    // Update is called once per frame
    void Update()
    {
        var myPosition = transform.position;
        var tarPosition = target.position;
        
        MoveCam(myPosition, tarPosition);
        ZoomCam(tarPosition);
    }

    private void MoveCam(Vector3 myPosition, Vector3 tarPosition)
    {
        
        
        //_diff = myPosition.y - tarPosition.y;
        if (!character.isGrounded)
        {
            _offset = new Vector3(offX, _diff, offZ);
        }
        _offset = new Vector3(offX, offY, offZ); //the cam doesn't move on the Y axis
        Vector3 targetPosition = tarPosition + _offset;
        transform.position = Vector3.SmoothDamp(myPosition, targetPosition, ref _velocity, SmoothTime);
    }

    private void ZoomCam(Vector3 tarPosition)
    {
        var targetSize=1f;
        _distanceZoomIn = _zoomInPoint - tarPosition.x;
        _distanceZoomOut =  tarPosition.x - _zoomOutPoint;
        //Debug.Log(_distanceZoomIn);
        //if (!(_distanceZoomIn > 0) || !(_distanceZoomOut > 0)) return; //will play only if we are in between the points
        if (_distanceZoomIn < _distanceZoomOut) //zooming IN
        {
            targetSize = 1 / _distanceZoomIn;
            Debug.Log(targetSize);
            //cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
            cam.orthographicSize = targetSize;

        }
        else
        {
            //Debug.Log("ZoomOut"); 
        }
        Debug.Log(_distanceZoomOut);
        Debug.Log(_distanceZoomIn);

    }
}
