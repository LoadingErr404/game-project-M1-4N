using System;
using UnityEngine;

public class CameraMoveFollow : MonoBehaviour
{
    [Header("Camera offset")]
    public float offX;
    public float offY;
    public float offZ;
    private Vector3 _offset;

    [Header("Zooming")] 
    public Transform zoomOutPoint; //object from scene
    public Transform zoomInPoint;
    public float zoomSpeed;
    public Camera cam;
    private float _originZoom;
    private static float _maxZoomPoint;  //for saving position from scene only once
    private static float _minZoomPoint;
    private float _distanceMin;
    private float _distanceMax;
    private float _zoom;

    private const float SmoothTime = 0f; //how long it takes to catch up

    private Vector3 _velocity = Vector3.zero;

    public Transform target;
    private float _diff;

    private void Start()
    {
        _maxZoomPoint = zoomInPoint.position.x;
        _minZoomPoint = zoomOutPoint.position.x;
        _originZoom = cam.orthographicSize;
    }


    // Update is called once per frame
    void Update()
    {
        MoveCam();
        ZoomCam();
    }

    private void MoveCam()
    {
        var myPosition = transform.position;
        var tarPosition = target.position;
        
        _diff = myPosition.y - tarPosition.y;
        _offset = new Vector3(offX, _diff, offZ); //the cam doesn't move on the Y axis
        Vector3 targetPosition = tarPosition + _offset;
        transform.position = Vector3.SmoothDamp(myPosition, targetPosition, ref _velocity, SmoothTime);
    }

    private void ZoomCam()
    {
        var myPosition = transform.position;
        var targetSize=0;
        if (myPosition.x < _minZoomPoint)
        {
            targetSize = 2;
        }
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetSize, Time.deltaTime * zoomSpeed);
    }
}
