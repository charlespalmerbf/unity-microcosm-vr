//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_1_Trigger : MonoBehaviour

{

	//Triggered When Hitting End Level Zone
    void OnTriggerEnter(Collider other)

    {

    	//Load New Scene
    	SceneManager.LoadScene(1);

    }

}
