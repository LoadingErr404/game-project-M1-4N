using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTimer : MonoBehaviour
{
    [Header("Time delay trigger")]
    public double timerDelayTrigger;

    [Header("Curent time")] 
    public double currentTime;
    
    // Start is called before the first frame update
    void Start(){
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        
    }

    public double TimerDelayTrigger
    {
        get => timerDelayTrigger;
        set => timerDelayTrigger = value;
    }

    public double CurrentTime
    {
        get => currentTime;
        set => currentTime = value;
    }
}
