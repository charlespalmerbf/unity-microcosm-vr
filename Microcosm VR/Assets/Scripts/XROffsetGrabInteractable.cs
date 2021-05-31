//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class XROffsetGrabInteractable : XRGrabInteractable

{
    //Setting All Private Variables.
    private Vector3 initialAttachLocalPos;
    private Quaternion initialAttachLocalRot;

    // Start Is Called Before First Frame Update
    void Start()

    {

        //Create Attach Point
        if(!attachTransform)

        {

            //Details For Object Grab
            GameObject grab = new GameObject("Grab Pivot");
            grab.transform.SetParent(transform, false);
            attachTransform = grab.transform;

        }

        //Setting Pos Of Object In Comparison To Player
        initialAttachLocalPos = attachTransform.localPosition;
        initialAttachLocalRot = attachTransform.localRotation;

    }

    protected override void OnSelectEnter(XRBaseInteractor interactor)

    {

        if(interactor is XRDirectInteractor) //If Interactor Is Touching, REF. XR Documentation 

        {

            attachTransform.position = interactor.transform.position;
            attachTransform.rotation = interactor.transform.rotation;

        }

        else //If Interactor Is Not Touching

        {

            attachTransform.localPosition = initialAttachLocalPos;
            attachTransform.localRotation = initialAttachLocalRot;

        }

        //This Class Hooks Into The Interaction System (via XRInteractionManager) And Provides Base Virtual Methods For Handling Hover And Selection.
        base.OnSelectEnter(interactor);

    }

}
