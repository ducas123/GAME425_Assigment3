// ISTA 425 / INFO 525 Algorithms for Games
//
// Sample code file

using UnityEngine;

public abstract class Car : MonoBehaviour
{
    public Transform centerOfMass;
    public WheelCollider wheelColliderLeftFront;
    public WheelCollider wheelColliderRightFront;
    public WheelCollider wheelColliderLeftBack;
    public WheelCollider wheelColliderRightBack;

    public Transform wheelLeftFront;
    public Transform wheelRightFront;
    public Transform wheelLeftBack;
    public Transform wheelRightBack;
    private Rigidbody _rigidbody;

    public float motorTorque = 200f;
    public float breakForce = 700f;
    public float maxSteer = 20f;

    public float moveInput;
    public float steerInput;
    public bool brakeInput;
    private float currentBreakForce;
    private float currentSteerAngle;

    // Start is called before the first frame update
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _rigidbody.centerOfMass = centerOfMass.localPosition;
    }

    private void FixedUpdate()
    {
        SetInputs();

        HandleMotor();
        HandleSteering();
        UpdateWheels();
    }

    public abstract void SetInputs();

    public void HandleMotor()
    {
        wheelColliderLeftFront.motorTorque = moveInput * motorTorque;
        wheelColliderRightFront.motorTorque = moveInput * motorTorque;
        currentBreakForce = brakeInput ? breakForce : 0f;
        if (brakeInput)
            Debug.Log("Brake applied at " + breakForce + " Newton Meters");

        ApplyBreaking();
    }

    public void ApplyBreaking()
    {
        wheelColliderLeftBack.brakeTorque = currentBreakForce;
        wheelColliderLeftFront.brakeTorque = currentBreakForce;
        wheelColliderRightBack.brakeTorque = currentBreakForce;
        wheelColliderRightFront.brakeTorque = currentBreakForce;
    }

    public void HandleSteering()
    {
        currentSteerAngle = maxSteer * steerInput;
        wheelColliderLeftFront.steerAngle = currentSteerAngle;
        wheelColliderRightFront.steerAngle = currentSteerAngle;
    }

    public void UpdateWheels()
    {
        UpdateSingleWheel(wheelColliderLeftBack, wheelLeftBack);
        UpdateSingleWheel(wheelColliderRightBack, wheelRightBack);
        UpdateSingleWheel(wheelColliderLeftFront, wheelLeftFront);
        UpdateSingleWheel(wheelColliderRightFront, wheelRightFront);
    }
    public void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform)
    {
        Vector3 pos;
        Quaternion rot;

        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
}
