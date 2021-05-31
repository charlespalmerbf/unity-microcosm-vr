//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class LocomotionController : MonoBehaviour

{

    //Setting All Public Variables.
    public XRController leftTeleportRay;
    public XRController rightTeleportRay;
    public InputHelpers.Button teleportActivationButton;
    public float activationThreshold = 0.1f;
    public XRRayInteractor leftInteractorRay;
    public XRRayInteractor rightInteractorRay;
    public bool EnableLeftTeleport { get; set; } = true;
    public bool EnableRightTeleport { get; set; } = true;

    // Update Is Called Once Per Frame
    void Update()

    {

        Vector3 pos = new Vector3();
        Vector3 norm = new Vector3();
        int index = 0;
        bool validTarget = false;

        if(leftTeleportRay) //Handler For Left Teleport Ray

        {

            //If Teleport Button Has Been Pressed
            bool isLeftInteractorRayHovering = leftInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);

            //If Teleport Button Has Been Released
            leftTeleportRay.gameObject.SetActive(EnableLeftTeleport && CheckIfActivated(leftTeleportRay) && !isLeftInteractorRayHovering);

        }

        if (rightTeleportRay) //Handler For Right Teleport Ray

        {

            //If Teleport Button Has Been Pressed
            bool isRightInteractorRayHovering = rightInteractorRay.TryGetHitInfo(ref pos, ref norm, ref index, ref validTarget);

            //If Teleport Button Has Been Released
            rightTeleportRay.gameObject.SetActive(EnableRightTeleport && CheckIfActivated(rightTeleportRay) && !isRightInteractorRayHovering);

        }

    }

    public bool CheckIfActivated(XRController controller) //Check To See If Button Has Been Pressed

    {

        //Check If Trigger Is Pressed, Pass Back True/False and isActivated.
        InputHelpers.IsPressed(controller.inputDevice, teleportActivationButton, out bool isActivated, activationThreshold);

        //Return True/False
        return isActivated;

    }

}



