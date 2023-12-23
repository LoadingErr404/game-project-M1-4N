using System;
using UnityEngine;
using UnityEngine.Serialization;

public class JumpTimerCooldown : MonoBehaviour
{
    public bool ableToJump;
    public float cooldown;

    public CharacterController2D characterController2D;
    // Start is called before the first frame update
    void Start()
    {
        ableToJump = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("Delta time: "+ Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
            ableToJump = false; //important for CharacterController2D and CharacterBehavior
            var timeLeft = cooldown;
            
            do
            {
                timeLeft -= Time.deltaTime;
               
                
            } while (timeLeft > 0);
            Debug.Log("Time left "+ timeLeft);
            ableToJump = true;
            
        
        
    }
}
