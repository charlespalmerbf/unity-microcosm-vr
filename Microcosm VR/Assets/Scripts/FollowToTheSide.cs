//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowToTheSide : MonoBehaviour

{
	//Setting All Public Variables.
    public Transform target;
    public Vector3 offset;

    // Update Is Called Once Per Frame
    void FixedUpdate()

    {

    	//Follow To Side Calculations
        transform.position = target.position + Vector3.up * offset.y
            + Vector3.ProjectOnPlane(target.right,Vector3.up).normalized * offset.x
            + Vector3.ProjectOnPlane(target.forward, Vector3.up).normalized * offset.z;

        //The Euler angles are three angles introduced by Leonhard Euler to describe the orientation of a rigid body with respect to a fixed coordinate system. They will be used throughout Microcosm's Development.
        transform.eulerAngles = new Vector3(0, target.eulerAngles.y, 0);

    }

}