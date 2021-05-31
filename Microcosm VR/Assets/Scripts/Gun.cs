//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour

{

	//Setting All Public Variables.
    public float speed = 40;
    public GameObject bullet;
    public Transform barrel;
    public AudioSource audioSource;
    public AudioClip audioClip;


    //On Fire Action
    public void Fire()

    {

        //Spawn a Projectile At The End Of The Gun Object
        GameObject spawnedBullet = Instantiate(bullet, barrel.position, barrel.rotation);

        //Set Speed And Direction Of Projectile 
        spawnedBullet.GetComponent<Rigidbody>().velocity = speed * barrel.forward;

        //Play Audio Upon Fire Action
        audioSource.PlayOneShot(audioClip);

        //Destory Projectile After 2 Seconds 
        Destroy(spawnedBullet, 2);

    }
}