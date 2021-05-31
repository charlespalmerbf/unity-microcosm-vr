//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class PlayOnCollision : MonoBehaviour

{
	//Setting All Private Variables.
    private AudioSource audioSource;

    //If Player Collides With Object
    void OnCollisionEnter(Collision collision)

    {

    	//Play Audio
        audioSource.Play();

    }
    
}
