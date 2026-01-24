using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    UnityEngine.Quaternion currentRotation;
    public Rigidbody rb;
    public float liftCoefficent;
    public float liftingArea;
    public float dragCoefficent;
    public float crosssectArea;
    public float airDensity;
    public float Velo;
    public float altitude;
    public float AoA;
    public float dynamicPressure;
    public float Weight;
    public float Lift;
    public float Drag;
    public float m = 1f;
    public float ground;
    public float thrust;
    public float pitchrate;
    public float rollrate;
    public float stabilizeCoefficent;
    public float stabilizes;
    public float trueHeading;
    public float rudderArea;
    public static float money;
    public float distance;
    public GameObject refpoint;
    
    public Transform target;
    public float rotStiffness = 10f;
    public float damping = 2f;
    public float sensitivity = 2f;
    //public float pitch = 0f;
    //public float roll = 0f;
    public float yaw = 0f;
    public float torqueMultiplier = 2f;


    public Upgrades upgrades;

    public float throttleIncrement = 0.1f;
    public float maxThrottle = 200f;
    public float responsiveness = 10f;
    public float throttle;
    public float roll;
    public float pitch;
    // Start is called before the first frame update
    void Start()
    {
        UnityEngine.Cursor.lockState = CursorLockMode.Locked;
        ground = 0f;
        thrust = 50f;
        liftingArea = 1;
        crosssectArea = 1;
        rudderArea = 0.1f;
        transform.rotation = UnityEngine.Quaternion.identity;
        UnityEngine.Quaternion deltaRotation = transform.rotation;
        m = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        roll += Input.GetAxis("Mouse X") * sensitivity;
        pitch -= Input.GetAxis("Mouse Y") * -sensitivity;
        if (Input.GetKey(KeyCode.K))
        {
            Upgrades.totalmoney = Upgrades.totalmoney + money;
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

    }
    private void FixedUpdate()
    {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        //UnityEngine.Quaternion rollRotation = new UnityEngine.Quaternion(0f, roll * 0.0174f, 0f, 0.2f);
        //UnityEngine.Quaternion pitchRotation = new UnityEngine.Quaternion(0f, 0f, pitch * 0.0174f, 0.2f);
        //UnityEngine.Quaternion yawRotation = new UnityEngine.Quaternion(yaw * 0.0174f, 0f, 0f, 0.2f);




        var localVelocity = transform.InverseTransformDirection(rb.velocity);
       
        Lift = liftCoefficent * dynamicPressure * liftingArea;
        Drag = dragCoefficent * dynamicPressure * crosssectArea;
        stabilizes = stabilizeCoefficent * dynamicPressure * rudderArea;
        Weight = m * -9.81f;
        dynamicPressure = 0.5f * airDensity * Velo * 2;
        airDensity = 1.224f - (0.000109f * altitude);
        liftCoefficent = (2 * 3.14f) * AoA;
        stabilizeCoefficent = (2 * 3.14f) * Input.compass.trueHeading;

        //https://www.youtube.com/watch?v=fThb5M2OBJ8 WATCH THIS!!!


        Velo = rb.velocity.magnitude;
        altitude = ground + transform.position.y;
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(UnityEngine.Vector3.right * thrust);
        }

        //UnityEngine.Quaternion targetrotation = transform.rotation = pitchRotation * rollRotation * yawRotation;
        //UnityEngine.Quaternion deltaRotation = targetrotation * UnityEngine.Quaternion.Inverse(rb.rotation);

       // deltaRotation.ToAngleAxis(out float angle, out UnityEngine.Vector3 axis);


       // UnityEngine.Vector3 torqueInput = axis * angle * torqueMultiplier;
        pitchrate = 1f;
        rollrate = 1f;

        //rb.AddRelativeTorque(torqueInput, ForceMode.Force);


        distance = UnityEngine.Vector3.Distance(transform.position, refpoint.transform.position);
        money = distance * 0.5f;
    }
    public void EndGame()
    {
        
        
        

    }
}
