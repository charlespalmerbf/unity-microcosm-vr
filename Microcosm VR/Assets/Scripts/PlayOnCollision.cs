using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.Audio;


public class PlayOnCollision : MonoBehaviour

{

    private AudioSource audioSource;

    void OnCollisionEnter(Collision collision)

    {

        audioSource.Play();

    }
    
}
