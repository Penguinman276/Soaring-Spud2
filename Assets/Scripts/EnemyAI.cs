using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    public Rigidbody rb;

    public PlayerControls player;
    public float Velo;

    public MachineGun machineGun;

    [Header("Enemy AI")]
    public float detectionRange = 1000f;
    public float maxBank = 60f;
    [Header("AI Throttle")]
    public float cruiseThrottle = 0.75f;
    public float attackThrottle = 1f;
    public float throttleChangeSpeed = 0.3f;

    private float horizontalInput;
    private float verticalInput;


    public Transform target;

    
    
    
  
   
  //  public Vector3 startpos;
   // Quaternion orignialrotation;


    public float throttleIncrement = 0.01f;

    private float throttle;
  
    public disable disable;
  
    

    public float Flyspeed;
    public float maxspeed;
    public float YawAmount = 120;
    private float Yaw;
    private float pitch;
    private float roll;
    public float upgdrag;

   
   



    public bool gamestart;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    




    void Start()
    {
        
      
        Quaternion orignialrotation = transform.rotation;
        
        gamestart = true;
        upgdrag = 3;


    }
    private void CalculateAIInputs()
    {
        if (target == null)
            return;

        Vector3 direction =
            (target.position - transform.position).normalized;

        // Convert target direction to local aircraft space
        Vector3 localDirection =
            transform.InverseTransformDirection(direction);

        // Generate flight inputs
        horizontalInput = Mathf.Clamp(-localDirection.x, -1f, 1f);

        verticalInput = Mathf.Clamp(-localDirection.y, -1f, 1f);
        float distance = Vector3.Distance(
        transform.position,
        target.position
    );

        float desiredThrottle;

        if (distance > 300f)
        {
            desiredThrottle = attackThrottle;
        }
        else
        {
            desiredThrottle = cruiseThrottle;
        }

        throttle = Mathf.MoveTowards(
            throttle,
            desiredThrottle,
            throttleChangeSpeed * Time.fixedDeltaTime
        );
    }


    private void Update()
    {


        Debug.DrawRay(transform.position,
    transform.forward * 20f, Color.blue);

        Debug.DrawRay(transform.position,
            transform.up * 20f, Color.green);

    }







    private void FixedUpdate()
    {
        CalculateAIInputs();
        Flyspeed = 60 * throttle;
        Flyspeed = Mathf.Clamp(Flyspeed, 0.0f, 50.0f);
       
        transform.position += transform.forward * Flyspeed * Time.deltaTime;



       




        if (player.gamestart == true)
        {
             float pitch = verticalInput * 60f * Time.deltaTime;
             float roll = horizontalInput * 90f * Time.deltaTime;
            transform.Rotate(pitch, 0f, roll, Space.Self);








        }
     
            
            
           

     




    }


    private Vector3 GetPredictedPosition()
    {
        Rigidbody playerRb = player.GetComponent<Rigidbody>();

        if (playerRb == null)
            return target.position;

        float distance = Vector3.Distance(
            machineGun.muzzle.position,
            target.position
        );

        float travelTime = distance / machineGun.tracerSpeed;

        travelTime = Mathf.Clamp(travelTime, 0f, 3f);

        return target.position + playerRb.velocity * travelTime;
        }
        private void Attack()
        {
        if (target == null || machineGun == null)
            return;

        Vector3 predictedPosition = GetPredictedPosition();

        Vector3 aimDirection =
            predictedPosition - machineGun.muzzle.position;

        float angle = Vector3.Angle(
            machineGun.muzzle.forward,
            aimDirection
        );

        float distance = Vector3.Distance(
            machineGun.muzzle.position,
            target.position
        );

        if (distance < 400f && angle < 8f)
        {
            machineGun.AIFire();
        }
        }









    //https://www.youtube.com/watch?v=7vAHo2B1zLc WATCH THIS!!!













    //public void ContinueGame()
    // {
    //  gamestart = true;
    //   rb.drag = upgdrag;
    //   rb.constraints = RigidbodyConstraints.None;



    // upgmanager.Speedupg.interactable = false;
    //  upgmanager.Agilityupg.interactable = false;
    //  upgmanager.Fuelrefill.interactable = false;


    //    }
}

