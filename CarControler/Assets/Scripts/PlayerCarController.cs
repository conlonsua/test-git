using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCarController : MonoBehaviour
{
    [Header("Wheels Collider")]
    public WheelCollider frontLeftWheelCollider;
    public WheelCollider frontRightWheelCollider;
    public WheelCollider backLeftWheelCollider;
    public WheelCollider backRightWheelCollier;

    [Header("Wheels Transform")]
    public Transform frontLeftWheelTransform;
    public Transform frontRightWheelTransform;
    public Transform backLeftWheelTransform;
    public Transform backRightWheelTransform;

    [Header("Car Engine")]
    //lực gia tốc tối đa
    public float accenlerationForce = 300f;
    //lực phanh tối đa
    public float breakingForce = 3000f;
    //Lực phanh hiện tại
    private float presentBreakForce = 0f;
    //lực gia tốc hiện tại
    private float presentAcceleration = 0f;

    [Header("Car Steering")]
    public float wheelsTorque = 35f;
    private float presentTurAngle = 0f;

    private void Update(){
        MoveCar();
        CarSteering();
    }

    private void MoveCar(){
        //hệ thống dẫn động bánh trước
        frontLeftWheelCollider.motorTorque = presentAcceleration;
        frontRightWheelCollider.motorTorque = presentAcceleration;
        backLeftWheelCollider.motorTorque = presentAcceleration;
        backRightWheelCollier.motorTorque = presentAcceleration;

        presentAcceleration = accenlerationForce * Input.GetAxis("Vertical");
    }

    private void CarSteering(){
        presentTurAngle = wheelsTorque * Input.GetAxis("Horizontal");
        frontLeftWheelCollider.steerAngle = presentTurAngle;
        frontRightWheelCollider.steerAngle = presentTurAngle;
    }

}
