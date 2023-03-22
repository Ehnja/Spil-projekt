using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelController : MonoBehaviour
{
    [SerializeField] WheelCollider frontRight;
    [SerializeField] WheelCollider frontLeft;
    [SerializeField] WheelCollider backRight;
    [SerializeField] WheelCollider backLeft;

    [SerializeField] Transform frontRightTransform;
    [SerializeField] Transform frontLeftTransform;
    [SerializeField] Transform backRightTransform;
    [SerializeField] Transform backLeftTransform;

    public float acceleration = 500f;
    public float breakingForce = 300f;
    public float maxTurnAngle = 15f;

    private float currentAcceleration = 0f;
    private float currentBreakForce = 0f;
    private float currentTurnAngle = 0f;

    public int lapNumber;
    public int checkpointIndex;

    private void Start()
    {
        lapNumber = 1;
        checkpointIndex = 0;
    }
    private void FixedUpdate()
    {
        // Hent acceleration fra vertikal akserne, (W og S keys)
        currentAcceleration = acceleration * Input.GetAxis("Vertical");

        // Hvis der trykkes mellemrum, tildeles currentBreakForce en værdi
        if (Input.GetKey(KeyCode.Space))
            currentBreakForce = breakingForce;
        else
            currentBreakForce = 0f;

        // Tildel acceleration til forhjul
        frontRight.motorTorque = currentAcceleration;
        frontLeft.motorTorque = currentAcceleration;

        frontRight.brakeTorque = currentBreakForce;
        frontLeft.brakeTorque = currentBreakForce;
        backRight.brakeTorque = currentBreakForce;
        backLeft.brakeTorque = currentBreakForce;

        // Håndtere styringen af bilen
        currentTurnAngle = maxTurnAngle * Input.GetAxis("Horizontal");
        frontRight.steerAngle = currentTurnAngle;
        frontLeft.steerAngle = currentTurnAngle;

        // Opdater hjul mesh, sådan hjul følger den vej der drejes til.
        UpdateWheel(frontRight, frontRightTransform);
        UpdateWheel(frontLeft, frontLeftTransform);
        UpdateWheel(backRight, backRightTransform);
        UpdateWheel(backLeft, backLeftTransform);
    }

    void UpdateWheel(WheelCollider col, Transform trans)
    {
        // Hent wheel collider position
        Vector3 position;
        Quaternion rotation;
        col.GetWorldPose(out position, out rotation);

        // Tildel wheel transform position
        trans.position = position;
        trans.rotation = rotation * Quaternion.Euler(0,0,90);
    }
}
