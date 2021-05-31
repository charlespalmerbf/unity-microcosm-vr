//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class RestartTrigger : MonoBehaviour
{

    private Scene scene;

    // Start Is Called Before First Frame Update
    void Start()

    {

        scene = SceneManager.GetActiveScene(); //Get The Current Active Scene

    }

    // Update Is Called Once Per Frame
    void OnTriggerEnter(Collider other)

    {

        if(other.gameObject.tag == "Player") //If Player Colides With Zone

        {

            SceneManager.LoadScene(SceneManager.GetActiveScene().name); //Reload Current Scene

        }

    }
  
}
