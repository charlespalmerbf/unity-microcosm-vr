using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class Climber : MonoBehaviour

{

    private CharacterController character;

    public static XRController climbingHand;
    
    private ContinuousMovement continuousMovement;

    // Start is called before the first frame update
    void Start()
    {
        character = GetComponent<CharacterController>();
        continuousMovement = GetComponent<ContinuousMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()

    {

        if(climbingHand) //If the player is begining a climb interaction.

        {

            continuousMovement.enabled = false;   //Stop character movement using the joystick.

            Climb(); //Climb Init.

        }

        else

        {

            continuousMovement.enabled = true; //Allow player to move with joystick.

        }

    }

    //Climbing Computations
    void Climb()

    {

    	//Get device position on the hand instigating the climb and allow the player to move based on velocity of controller along Vector 3.

        InputDevices.GetDeviceAtXRNode(climbingHand.controllerNode).TryGetFeatureValue(CommonUsages.deviceVelocity, out Vector3 velocity); 

        character.Move(transform.rotation * -velocity * Time.fixedDeltaTime);

    }
    
}
