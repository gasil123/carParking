using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarControllerScript : MonoBehaviour
{
    public Transform com;
    Rigidbody rb;

    public List<WheelCollider> Motorwheels;
    public List<WheelCollider> Steerwheels;
    public float AccelerationSpeed;
    public float maxMotorTorque;
    public float maxBrakeTorque;
    public float dragSensitivity;
    public float maxSteeringAngle = 30f;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rb.centerOfMass = com.localPosition;

        bool isAcceleration = Input.GetKey(KeyCode.W);
        bool isReverse = Input.GetKey(KeyCode.S);
        //bool leftStreer = ;
        //bool rightStreer = ;
        bool isbreaking = Input.GetKey(KeyCode.Space);

        foreach (WheelCollider Wh in Motorwheels)
        {
             
            if (isAcceleration && Wh.rpm < maxMotorTorque && !isbreaking)
            {
                rb.drag = 0;
                Wh.motorTorque += AccelerationSpeed;
            }
      
            else if (isReverse && Wh.rpm > -maxMotorTorque && !isbreaking)
            {
                rb.drag = 0;
                Wh.motorTorque -= AccelerationSpeed;
            }
      
            else if (isbreaking)
            {
                Wh.brakeTorque = maxBrakeTorque;
            }
            else
            {
                if (Wh.motorTorque > 0)
                {
                    Wh.motorTorque --;
                }
                if (Wh.motorTorque < 0)
                {
                    Wh.motorTorque ++;
                }

                rb.drag = dragSensitivity;
                Wh.brakeTorque = 0;
                Wh.motorTorque = 0;
            }
            if (!isbreaking)
            { 
                Wh.brakeTorque = 0;
            }
           // Debug.Log("speed is"+Wh.motorTorque);
        }
        foreach (WheelCollider Sh in Steerwheels)
        {
            if (isbreaking)
            {
                Sh.brakeTorque = maxBrakeTorque;
            }
            else
            {
                Sh.brakeTorque = 0;
            }
            if (Input.GetKey(KeyCode.A))
            {
                Sh.steerAngle = -maxSteeringAngle;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                Sh.steerAngle = maxSteeringAngle;
            }
            else
            {
                Sh.steerAngle = 0;
            } 
        }
    }
}
