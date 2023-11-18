using UnityEngine;

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
    

    // Update is called once per frame
    void Update()
    {
        var myPosition = transform.position;
        var tarPosition = target.position;
        
        _diff = myPosition.y - tarPosition.y;
        _offset = new Vector3(offX, _diff, offZ); //the cam doesn't move on the Y axis
        Vector3 targetPosition = tarPosition + _offset;
        transform.position = Vector3.SmoothDamp(myPosition, targetPosition, ref _velocity, SmoothTime);
    }
}
