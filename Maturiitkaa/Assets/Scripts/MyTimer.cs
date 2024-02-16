using UnityEngine;

public class MyTimer : MonoBehaviour
{
    [Header("Time delay trigger")]
    public double timerDelayTrigger;

    [Header("Current time")] 
    public double currentTime;
    

    // Update is called once per frame
    private void Update()
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
