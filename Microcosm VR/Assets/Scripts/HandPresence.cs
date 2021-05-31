//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class HandPresence : MonoBehaviour

{
    //Setting All Public Variables.
    public bool showController = false;
    public InputDeviceCharacteristics controllerCharacteristics;
    public List<GameObject> controllerPrefabs;
    public GameObject handModelPrefab;
    
    //Setting All Private Variables.
    private InputDevice targetDevice;
    private GameObject spawnedController;
    private GameObject spawnedHandModel;
    private Animator handAnimator;

    // Start Is Called Before First Frame Update
    void Start()

    {

        TryInitialize(); //Run TryInitialize Function
    }

    void TryInitialize() //Start Of TryInitialize Function

    {

        List<InputDevice> devices = new List<InputDevice>();

        InputDevices.GetDevicesWithCharacteristics(controllerCharacteristics, devices); //Get Current Device Data

        foreach (var item in devices) //Loop Through Possible Models In Array

        {

            Debug.Log(item.name + item.characteristics);

        }

        if (devices.Count > 0)

        {

            targetDevice = devices[0];

            GameObject prefab = controllerPrefabs.Find(controller => controller.name == targetDevice.name); //Attempt To Match Controller to Target Controller

            if (prefab) //If Corresponding Model Was Found

            {

                //Spawn Controller Model Into Playspace
                spawnedController = Instantiate(prefab, transform);

            }

            else //If Coresponding Model Was Not Found

            {
                Debug.LogError("Did not find corresponding controller model");
                spawnedController = Instantiate(controllerPrefabs[0], transform);
            }

            //If Controller Cannot Be Found Spawn Hand Models
            spawnedHandModel = Instantiate(handModelPrefab, transform);
            handAnimator = spawnedHandModel.GetComponent<Animator>();

        }
    }

    //Update Hand Model Based On Button Mapping
    void UpdateHandAnimation()

    {

        if(targetDevice.TryGetFeatureValue(CommonUsages.trigger, out float triggerValue))

        {

            handAnimator.SetFloat("Trigger", triggerValue);

        }

        else

        {

            handAnimator.SetFloat("Trigger", 0);

        }


        if (targetDevice.TryGetFeatureValue(CommonUsages.grip, out float gripValue))

        {

            handAnimator.SetFloat("Grip", gripValue);

        }

        else

        {

            handAnimator.SetFloat("Grip", 0);

        }

    }

    // Update Is Called Once Per Frame
    void Update()

    {

        //If The Players Device Is Not Valid
        if(!targetDevice.isValid)

        {

            //Run TryInitialize Again
            TryInitialize();

        }

        else

        {

            if (showController) //If Controller Has Been Identified, Display It.

            {
                spawnedHandModel.SetActive(false);
                spawnedController.SetActive(true);
            }

            else //If Not, Display Hand Model.

            {
                spawnedHandModel.SetActive(true);
                spawnedController.SetActive(false);
                UpdateHandAnimation();
            }

        }

    }

}
