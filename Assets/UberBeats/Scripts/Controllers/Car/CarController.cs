using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float steerAngle;
    private bool isBreaking;

    [Header("Wheel Colliders")]
    public List<WheelCollider> Front_Wheels; 
    public List<WheelCollider> Back_Wheels;

    [Header("Wheel Transforms")]
    public List<Transform> Front_Wheel_Transforms; //The front wheel transforms
    public List<Transform> Back_Wheel_Transforms; //The rear wheel transforms

    [Header("Wheel Transforms Rotations")]
    public List<Vector3> Front_Wheel_Rotation; //The front wheel rotation Vectors
    public List<Vector3> Back_Wheel_Rotation; //The rear wheel rotation Vectors


    public float maxSteeringAngle = 30f;
    public float motorForce = 400f;
    public float brakeForce = 150f;
    public float maximumSpeed=50.0f;


    private float steering;
    private float acceleration;

    public Rigidbody rb;
    private float Brakes = 0f; //Brakes

    

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody

    }


    private void FixedUpdate()
    {
       
    }

    public void SetSteering(float steer)
    {
        steering = steer;
    }
    public void SetAcceleration(float acc)
    {
        acceleration = acc;
    }
    private void Accelerate()
    {
         foreach(WheelCollider Wheel in Back_Wheels){
                Wheel.motorTorque = acceleration * ((motorForce * 5)/(Back_Wheels.Count + Front_Wheels.Count));
            }
    }

    private void Turn()
    {
        foreach(WheelCollider Wheel in Front_Wheels){
                Wheel.steerAngle = steering * maxSteeringAngle; //Turn the wheels
            }
    }

    private void StopAcceleration()
    {
        foreach(WheelCollider Wheel in Back_Wheels){
                Wheel.motorTorque = 0.0f;
            }
    }

    private void RotateWheels()
    {
        //Rotating The Wheels Meshes so they have the same position and rotation as the wheel colliders
        var pos = Vector3.zero; //position value (temporary)
        var rot = Quaternion.identity; //rotation value (temporary)
        for (int i = 0; i < (Back_Wheels.Count); i++)
        {
            Back_Wheels[i].GetWorldPose(out pos, out rot); //get the world rotation & position of the wheel colliders
            Back_Wheel_Transforms[i].position = pos; //Set the wheel transform positions to the wheel collider positions
            Back_Wheel_Transforms[i].rotation = rot * Quaternion.Euler(Back_Wheel_Rotation[i]); //Rotate the wheel transforms to the rotation of the wheel collider(s) and the rotation offset
        }

        for (int i = 0; i < (Front_Wheels.Count); i++)
        {
            Front_Wheels[i].GetWorldPose(out pos, out rot); //get the world rotation & position of the wheel colliders
            Front_Wheel_Transforms[i].position = pos; //Set the wheel transform positions to the wheel collider positions
            Front_Wheel_Transforms[i].rotation = rot * Quaternion.Euler(Front_Wheel_Rotation[i]); //Rotate the wheel transforms to the rotation of the wheel collider(s) and the rotation offset
        }

    }

    public void ApplyBrake()
    {
         foreach(WheelCollider Wheel in Front_Wheels){
            Wheel.brakeTorque = Brakes; //set the brake torque of the wheels to the brake torque
        }

        foreach(WheelCollider Wheel in Back_Wheels){
            Wheel.brakeTorque = Brakes; //set the brake torque of the wheels to the brake torque
        }
    }
    public void Brake(bool isBreaking)
    {
        if(!isBreaking)
            return;
        Brakes = brakeForce;

    }

   

    public float GetCarSpeed()
    {
        return rb.velocity.magnitude * 3.6f;
    }



}