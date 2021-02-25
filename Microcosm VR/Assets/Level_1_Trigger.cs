using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Level_1_Trigger : MonoBehaviour
{

    void OnTriggerEnter(Collider other)

    {
    	SceneManager.LoadScene(1);
    }

  
}
