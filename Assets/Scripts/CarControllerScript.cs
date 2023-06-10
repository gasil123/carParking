using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleInputNamespace;

public class CarControllerScript : MonoBehaviour
{
    [SerializeField]
    private float acceralaration = 800f;
    [SerializeField]
    private float breaking;
    [SerializeField]
    private float steeringAngle = 30f;
   // [SerializeField]
   // private GameObject ReverseCanvas;
    [SerializeField]
    private ParticleSystem[] smokeParticles;

    public Button ForwardButton;

    public GameObject COM;
    private Rigidbody rb;

    public WheelCollider FRcollider;
    public WheelCollider FLcollider;
    public WheelCollider RRcollider;
    public WheelCollider RLcollider;

    // public MeshRenderer FRmesh;
    //public MeshRenderer FLmesh;
    //public MeshRenderer RRmesh;
    //public MeshRenderer RLmesh;
    //bool forwardOrBackwardpressed;

    float forwardBackward;
    float steering;
    bool isbreaking;

    public void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        rb.centerOfMass = COM.transform.localPosition;

        Controlinputs();
        applyMotion();
        applyBreak();
        applySteering();
        addDrag();
        StartCoroutine(smokeWait());
    }

    public void Controlinputs()
    {
        Vector3 pos = transform.position;
        forwardBackward = Input.GetAxis("Vertical");
        steering = Input.GetAxis("Horizontal");
        isbreaking = Input.GetKey(KeyCode.Space);

       // forwardOrBackwardpressed = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S);

      //  if (forward < 0)
      //  {
      //    ReverseCanvas.SetActive(true);
      //  }
      //  else
      //  {
      //     ReverseCanvas.SetActive(false);
      // }
    }

    public void applyMotion()
    {
        FRcollider.motorTorque = forwardBackward * acceralaration;
        FLcollider.motorTorque = forwardBackward * acceralaration;
        
    }
    public void applyForward()
    {
        Debug.Log("functioncalled");
        FRcollider.motorTorque =  acceralaration;
        FLcollider.motorTorque =  acceralaration;
    } 
    public void applyBackward()
    {
        FRcollider.motorTorque =  -acceralaration;
        FLcollider.motorTorque =  -acceralaration;
    }

    public void addDrag()
    {
        addDragHelper(FRcollider);
        addDragHelper(FLcollider);
        addDragHelper(RRcollider);
        addDragHelper(RLcollider);
    }

    public void addDragHelper(WheelCollider collider)
    {
        if (collider.isGrounded)
        {
            if (forwardBackward == 0)
            {
                rb.drag += Time.deltaTime * 0.2f;
            }
            else
            {
                rb.drag = 0;
            }
        }
    }

    public void applyBreak()
    {
        if (isbreaking)
        {
            FRcollider.brakeTorque =   breaking;
            FLcollider.brakeTorque =   breaking;
            RRcollider.brakeTorque =   breaking;
            RLcollider.brakeTorque =   breaking;
        }
        else if(!isbreaking)
        {
            FRcollider.brakeTorque = 0;
            FLcollider.brakeTorque = 0;
            RRcollider.brakeTorque = 0;
            RLcollider.brakeTorque = 0;
        }
    }

    public void applySteering()
    {
        FRcollider.steerAngle = steering * steeringAngle;
        FLcollider.steerAngle = steering * steeringAngle;
    }

   // public void applyRotation()
   // {
       // rotateWheels(RRcollider, RRmesh);
     //   rotateWheels(RLcollider, RLmesh);
      ////  rotateWheels(FRcollider, FRmesh);
      //  rotateWheels(FLcollider, FLmesh);
    //}
    //public void rotateWheels(WheelCollider colliders, MeshRenderer meshes)
  //  {
    //    Quaternion quat;
    //    Vector3 pos;
    //    colliders.GetWorldPose(out pos, out quat);
    //    meshes.transform.position = pos;
    //    meshes.transform.rotation = quat;

    //}

    private IEnumerator smokeWait()
    {
        yield return new WaitForSeconds(3f);
        if (forwardBackward > 0)
        {
            foreach (ParticleSystem smoke in smokeParticles)
            {
                smoke.Play();
            }
        }
        else
        {
            foreach (ParticleSystem smoke in smokeParticles)
            {
                smoke.Pause();
            }
        }
    }
}

//using UnityEngine;
//using UnityEngine.UI;
//using System.Collections.Generic;
//using UnityEngine.EventSystems;

//public class CarControllerScript : MonoBehaviour
//{
//    public Button ForwarddButton;
//    public Button ReverseButton;
//    public Button RightButton;
//    public Button LeftButton;

//    public Transform com;
//    Rigidbody rb;

//    public List<WheelCollider> Motorwheels;
//    public List<WheelCollider> Steerwheels;
//    public float AccelerationSpeed;
//    public float maxMotorTorque;
//    public float maxBrakeTorque;
//    public float dragSensitivity;
//    public float maxSteeringAngle = 30f;

//    bool isAcceleration;
//    bool isReverse;
//    bool isbreaking;
//    bool leftStreer;
//    bool rightStreer;

//    public void Start()
//    {
//        rb = GetComponent<Rigidbody>();
//    }
//    private void FixedUpdate()
//    {
//        rb.centerOfMass = com.localPosition;

//        isAccelerating();
//        isReversing();
//        isBreaking();
//        isLeftSteering();
//        isRightSteering();

//        foreach (WheelCollider Wh in Motorwheels)
//        {

//            if (isAcceleration && Wh.rpm < maxMotorTorque && !isbreaking)
//            {
//                rb.drag = 0;
//                Wh.motorTorque += AccelerationSpeed;
//            }

//            else if (isReverse && Wh.rpm > -maxMotorTorque && !isbreaking)
//            {
//                rb.drag = 0;
//                Wh.motorTorque -= AccelerationSpeed;
//            }

//            else if (isbreaking)
//            {
//                Wh.brakeTorque = maxBrakeTorque;
//            }
//            else
//            {
//                if (Wh.motorTorque > 0)
//                {
//                    Wh.motorTorque --;
//                }
//                if (Wh.motorTorque < 0)
//                {
//                    Wh.motorTorque ++;
//                }

//                rb.drag = dragSensitivity;
//                Wh.brakeTorque = 0;
//                Wh.motorTorque = 0;
//            }
//            if (!isbreaking)
//            { 
//                Wh.brakeTorque = 0;
//            }
//           // Debug.Log("speed is"+Wh.motorTorque);
//        }
//        foreach (WheelCollider Sh in Steerwheels)
//        {
//            if (isbreaking)
//            {
//                Sh.brakeTorque = maxBrakeTorque;
//            }
//            else
//            {
//                Sh.brakeTorque = 0;
//            }
//            if (leftStreer)
//            {
//                Sh.steerAngle = -maxSteeringAngle* Time.timeScale;
//            }
//            else if (rightStreer)
//            {
//                Sh.steerAngle = maxSteeringAngle * Time.timeScale;
//            }
//            else
//            {
//                Sh.steerAngle = 0;
//            } 


//        }


//    }


//    public void isAccelerating()
//    {

//        isAcceleration = Input.GetKey(KeyCode.W) || ForwarddButton.GetComponent<ButtonController>().isbuttonClicked;
//    }
//    public void isReversing()
//    {
//        isReverse = Input.GetKey(KeyCode.S) || ReverseButton.GetComponent<ButtonController>().isbuttonClicked;
//    }
//    public void isBreaking()
//    {
//        isbreaking = Input.GetKey(KeyCode.Space);
//    }
//    public void isLeftSteering()
//    {
//       leftStreer = Input.GetKey(KeyCode.A) || LeftButton.GetComponent<ButtonController>().isbuttonClicked;
//    }
//    public void isRightSteering()
//    {
//        rightStreer = Input.GetKey(KeyCode.D) || RightButton.GetComponent<ButtonController>().isbuttonClicked;
//    }


//}
