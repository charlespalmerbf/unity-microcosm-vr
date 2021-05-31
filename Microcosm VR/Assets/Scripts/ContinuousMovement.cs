//Handling Package Imports
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class ContinuousMovement : MonoBehaviour

{
    //Setting All Public Variables.
    public float speed = 3;
    public XRNode inputSource;
    public float gravity = -9.81f;
    public LayerMask groundLayer;
    public float additionalHeight = 0.2f;

    //Setting All Private Variables.
    private float fallingSpeed;
    private XRRig rig;
    private Vector2 inputAxis;
    private CharacterController character;

    // Start Is Called Before First Frame Update
    void Start()
    {
        character = GetComponent<CharacterController>();
        rig = GetComponent<XRRig>();
    }

    // Update Is Called Once Per Frame
    void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        device.TryGetFeatureValue(CommonUsages.primary2DAxis, out inputAxis);
    }

    private void FixedUpdate()

    {

        CapsuleFollowHeadset();

        //Direction Determined By Data From Headset Input
        Quaternion headYaw = Quaternion.Euler(0, rig.cameraGameObject.transform.eulerAngles.y, 0);
        Vector3 direction = headYaw *  new Vector3(inputAxis.x, 0, inputAxis.y);

        //Move The Character In The Direction The Headset Is Facing
        character.Move(direction * Time.fixedDeltaTime * speed);

        //Enable Gravity
        bool isGrounded = CheckIfGrounded();

        //If The Player Is On The Ground
        if (isGrounded)

            fallingSpeed = 0;

        //If The Player Is Not On The Ground
        else

            fallingSpeed += gravity * Time.fixedDeltaTime;

        character.Move(Vector3.up * fallingSpeed * Time.fixedDeltaTime);

    }

    void CapsuleFollowHeadset()

    {

        //Calculates Tracking Information Based On Build In Headset Data
        character.height = rig.cameraInRigSpaceHeight + additionalHeight;
        Vector3 capsuleCenter = transform.InverseTransformPoint(rig.cameraGameObject.transform.position);
        character.center = new Vector3(capsuleCenter.x, character.height/2 + character.skinWidth , capsuleCenter.z);

    }

    bool CheckIfGrounded()

    {

        //Tells Us If The Player Is On The Ground
        Vector3 rayStart = transform.TransformPoint(character.center);

        //Calculating Distance From Ground And HasHit Detection
        float rayLength = character.center.y + 0.01f;
        bool hasHit = Physics.SphereCast(rayStart, character.radius, Vector3.down, out RaycastHit hitInfo, rayLength, groundLayer);

        //Returns True/False
        return hasHit;

    }

}
