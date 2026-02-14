using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Numerics;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    
   /// <summary>
   public Rigidbody rb;
   /// </summary>
   // public float liftCoefficent;
  //  public float liftingArea;
  //  public float dragCoefficent;
  // public float crosssectArea;
   //public float airDensity;
   public float Velo;
    public GameObject upgrade; 
    
  /// <summary>
  // public float altitude;
  /// </summary>
  // public float AoA;
//   public float dynamicPressure;
//    
  // public float Weight;
   //
   //public float Lift;
  // public float Drag;
  //  public float m = 1f;
   //public float ground;
    //public float thrust;
   /// <summary>
   /// public float pitchrate;
   /// </summary>
   //public float rollrate;
   //public float stabilizeCoefficent;
   // public float stabilizes;
   // public float trueHeading;
  /// public float rudderArea;
  //  public static float money;
   public float distance;
    //  public GameObject refpoint;
    public float money;
    public Transform target;
   public float rotStiffness = 10f;
   public float damping = 2f;
   public float sensitivity = 2f;
   public float pitch = 0f;
   public float roll = 0f;
   public float yaw = 0f;
   public float torqueMultiplier = 2f;
    public float totalmoney;
   
    public Upgrades upgrades;

    public float throttleIncrement = 0.1f;
    public float maxThrust = 200f;
    public float responsiveness = 10f;
    public float throttle;
    
    private float responseModifier
    {
        get {
            return (rb.mass / 10f) * responsiveness;
        }
    }
    // Start is called before the first frame update
    private void Awake()
    {
       rb = GetComponent<Rigidbody>();
       
    }
    private void HandleInputs()
    {
        roll = Input.GetAxis("Roll");
        pitch = Input.GetAxis("Pitch");
        yaw = Input.GetAxis("Yaw");

        if (Input.GetKey(KeyCode.Space)) throttle += throttleIncrement;
        else if (Input.GetKey(KeyCode.LeftControl)) throttle -= throttleIncrement;
        throttle = Mathf.Clamp(throttle, 0f, 100f);
    }
    void Start()
    {
       // UnityEngine.Cursor.lockState = CursorLockMode.Locked;
       //ground = 0f;
      // thrust = 50f;
       //liftingArea = 1;
      /// crosssectArea = 1;
     //rudderArea = 0.1f;
     // transform.rotation = UnityEngine.Quaternion.identity;
      // UnityEngine.Quaternion deltaRotation = transform.rotation;
       //m = 1f;
    }

    // Update is called once per frame
    //void Update()
    // {
    // roll += Input.GetAxis("Mouse X") * sensitivity;
    //pitch -= Input.GetAxis("Mouse Y") * -sensitivity;
    //if (Input.GetKey(KeyCode.K))
    //{
    //     Upgrades.totalmoney = Upgrades.totalmoney + money;
    //     UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    // }

    // }
    private void Update()
    {
        HandleInputs();
    }
    private void FixedUpdate()
    {

        rb.AddForce(transform.up * maxThrust * throttle);
        rb.AddTorque(transform.up * yaw * responseModifier);
        rb.AddTorque(transform.right * pitch * responseModifier);
        rb.AddTorque(transform.forward * roll * responseModifier); 
        // float vertical = Input.GetAxis("Vertical");
        //float horizontal = Input.GetAxis("Horizontal");

        //UnityEngine.Quaternion rollRotation = new UnityEngine.Quaternion(0f, roll * 0.0174f, 0f, 0.2f);
        //UnityEngine.Quaternion pitchRotation = new UnityEngine.Quaternion(0f, 0f, pitch * 0.0174f, 0.2f);
        //UnityEngine.Quaternion yawRotation = new UnityEngine.Quaternion(yaw * 0.0174f, 0f, 0f, 0.2f);




        //var localVelocity = transform.InverseTransformDirection(rb.velocity);

        // Lift = liftCoefficent * dynamicPressure * liftingArea;
        // Drag = dragCoefficent * dynamicPressure * crosssectArea;
        // stabilizes = stabilizeCoefficent * dynamicPressure * rudderArea;
        /// Weight = m * -9.81f;
        /// dynamicPressure = 0.5f * airDensity * Velo * 2;
        // airDensity = 1.224f - (0.000109f * altitude);
        // liftCoefficent = (2 * 3.14f) * AoA;
        // stabilizeCoefficent = (2 * 3.14f) * Input.compass.trueHeading;

        //https://www.youtube.com/watch?v=fThb5M2OBJ8 WATCH THIS!!!


        //Velo = rb.velocity.magnitude;
        // altitude = ground + transform.position.y;
        //if (Input.GetKey(KeyCode.Space))
        //{
        //    rb.AddRelativeForce(UnityEngine.Vector3.right * thrust);
        // }

        //UnityEngine.Quaternion targetrotation = transform.rotation = pitchRotation * rollRotation * yawRotation;
        //UnityEngine.Quaternion deltaRotation = targetrotation * UnityEngine.Quaternion.Inverse(rb.rotation);

        // deltaRotation.ToAngleAxis(out float angle, out UnityEngine.Vector3 axis);


        // UnityEngine.Vector3 torqueInput = axis * angle * torqueMultiplier;
        // pitchrate = 1f;
        // rollrate = 1f;

        //rb.AddRelativeTorque(torqueInput, ForceMode.Force);


        //  distance = UnityEngine.Vector3.Distance(transform.position, refpoint.transform.position);
        money = distance * 0.5f;
    }
    public void EndGame()
    {
        
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        

    }
}
