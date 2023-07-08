using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    [SerializeField] KeyCode leftPaddleInput;
    [SerializeField] KeyCode rightPaddleInput;

    [SerializeField] HingeJoint leftPaddle;
    [SerializeField] HingeJoint rightPaddle;

    [SerializeField] float springPower;

    [SerializeField] Rigidbody ball;
    void Start()
    {
        JointSpring jointSpring = leftPaddle.spring;
        jointSpring.spring = springPower;
        leftPaddle.spring = jointSpring;

        jointSpring = rightPaddle.spring;
        jointSpring.spring = springPower;
        rightPaddle.spring = jointSpring;

    }

    void Update() 
    { 
        if (Input.GetKey(leftPaddleInput))
        {
            ChangeHingePosition(leftPaddle, true, true);
        }
        else
        {
            ChangeHingePosition(leftPaddle, false, true);
        }

        if (Input.GetKey(rightPaddleInput))
        {
            ChangeHingePosition(rightPaddle, true, false);
        }
        else
        {
            ChangeHingePosition(rightPaddle, false, false);
        }
        
    }

    void ChangeHingePosition(HingeJoint paddleJoint, bool stressJoint, bool isLeftPaddle)
    {
        JointSpring jointSpring = paddleJoint.spring;

        float jointTargetPosition = stressJoint ? paddleJoint.limits.max : paddleJoint.limits.min;

        jointSpring.targetPosition = isLeftPaddle ? jointTargetPosition * -1 : jointTargetPosition;

        paddleJoint.spring = jointSpring;
    }
}
