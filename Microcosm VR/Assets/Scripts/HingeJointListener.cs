//Handling Package Imports
using UnityEngine;
using UnityEngine.Events;

public class HingeJointListener : MonoBehaviour
{
    //Angle Threshold To Trigger If We Reached Limit
    public float angleBetweenThreshold = 1f;
    //State Of The Hinge Joint : Either Reached Min Or Max Or None If In Between
    public HingeJointState hingeJointState = HingeJointState.None;

    //Event Called On Min Reached
    public UnityEvent OnMinLimitReached;
    //Event Called On Max Reached
    public UnityEvent OnMaxLimitReached;

    public enum HingeJointState { Min,Max,None}
    private HingeJoint hinge;

    //Start Is Called Before The First Frame Update
    void Start()

    {

        hinge = GetComponent<HingeJoint>();

    }

    private void FixedUpdate()

    {

        float angleWithMinLimit = Mathf.Abs(hinge.angle - hinge.limits.min);
        float angleWithMaxLimit = Mathf.Abs(hinge.angle - hinge.limits.max);

        //Reached Min
        if(angleWithMinLimit < angleBetweenThreshold)

        {
            
            if (hingeJointState != HingeJointState.Min)

                OnMinLimitReached.Invoke();

            hingeJointState = HingeJointState.Min;

        }

        //Reached Max
        else if (angleWithMaxLimit < angleBetweenThreshold)

        {

            if (hingeJointState != HingeJointState.Max)

                OnMaxLimitReached.Invoke();

            hingeJointState = HingeJointState.Max;

        }

        //No Limit Reached
        else

        {

            hingeJointState = HingeJointState.None;

        }

    }

}
