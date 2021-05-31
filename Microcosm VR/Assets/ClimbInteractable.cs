//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class ClimbInteractable : XRBaseInteractable

{

    //Setting All Public Variables.
    public AudioSource audioSource;
    public AudioClip audioClip;

    protected override void OnSelectEnter(XRBaseInteractor interactor) //When Entering Climb.

    {

        base.OnSelectEnter(interactor);

        if(interactor is XRDirectInteractor)

            //Climbing Hand Is Anchor.
            Climber.climbingHand = interactor.GetComponent<XRController>();

            //Play Audio When Interacting With Climb Nodes.
            audioSource.PlayOneShot(audioClip);

    }

    protected override void OnSelectExit(XRBaseInteractor interactor) //When Exiting Climb

    {

        base.OnSelectExit(interactor);
        
        if(interactor is XRDirectInteractor)

        {

            if(Climber.climbingHand && Climber.climbingHand.name == interactor.name) //If Climbing Hand & CH Name Contain The Same Value.

            {

                Climber.climbingHand = null; //Reset Value.

            }
        }
    }
}
