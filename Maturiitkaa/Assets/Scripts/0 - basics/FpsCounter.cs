using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FpsCounter : MonoBehaviour
{
    private int _lastFrameIndex;
    private float[] _frameDeltaTimeArray;
    public int fpsCount;
    
    private void Awake()
    {
        _frameDeltaTimeArray = new float[50];
    }
    
    private void Update()
    {
        _frameDeltaTimeArray[_lastFrameIndex] = Time.unscaledDeltaTime;
        _lastFrameIndex = (_lastFrameIndex + 1) % _frameDeltaTimeArray.Length;
        fpsCount = Mathf.RoundToInt(CalculateFPS());
    }

    private float CalculateFPS()
    {
        return _frameDeltaTimeArray.Length / _frameDeltaTimeArray.Sum();
    }
}