using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;

using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

using UnityEngine.UIElements;
using UnityEngine.UI;
using UnityEditor.Playables;
using UnityEngine.Analytics;


public class PlayerControls : MonoBehaviour
{
    
    public Rigidbody rb;

    
    public float Velo;
    public GameObject upgrade;

    
    public float distance;
    public GameObject refpoint;
    public float money;
    public Transform target;
  
    public int totalmoney;
    public UpgradeManager upgmanager;
    public distancetracker distancetrk;
    public float earnedmoney;
    public GameObject continuebutton;
    public Vector3 startpos;
    Quaternion orignialrotation;

   
    public float throttleIncrement = 0.01f;
  
    private float throttle;
    public float maxfuel = 100;
      public float fuel = 100;
    public disable disable;
    public Text speeddis;
    public string speeddisplay;

    public float Flyspeed;
    public float maxspeed;
    public float YawAmount = 120;
    private float Yaw;
    private float pitch;
    private float roll;
    public float upgdrag;

    public string fueldisplay;
    public Text fueltxt;

    

    public bool gamestart;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }
    private void HandleInputs()
    {
        
        if (Input.GetKey(KeyCode.Space))
        {
            throttle += throttleIncrement;
        }
        if (Input.GetKey(KeyCode.LeftControl))
        {
            throttle -= throttleIncrement;
        }

        throttle = Mathf.Clamp(throttle, 0.0f, 1f);    
         

    }


    void Start()
    {
        continuebutton.SetActive(false);
        startpos = transform.position;
        Quaternion orignialrotation = transform.rotation;
        startpos = transform.position;
        gamestart = true;
        upgdrag = 3;
        
        
    }

    
    private void Update()
    {
        HandleInputs();
        fueldisplay = "Fuel: " + fuel;
        fueltxt.text = fueldisplay;
        
    }


    

   
    

    private void FixedUpdate()
    {
        HandleInputs();
       // Flyspeed = 50 * throttle;
        //Flyspeed = Mathf.Clamp(Flyspeed, 0.0f, 50.0f);
        //earnedmoney = distancetrk.totalDistanceTraveled * 0.8f;
        
        transform.position += transform.forward * Flyspeed * Time.deltaTime;

        
        
            float horizontalInput = Input.GetAxis("Yaw");
            float verticalInput = Input.GetAxis("Pitch");
        
        


        if (gamestart == true)
        {
            float pitch = verticalInput * 60f * Time.deltaTime;
            float roll = -horizontalInput * 90f * Time.deltaTime;

            transform.Rotate(pitch, 0f, roll, Space.Self);
            fuel = fuel - (throttle * 100 * 0.001f);
            fuel = Mathf.Clamp(fuel, 0, maxfuel);
            if (fuel <= 0)
            {
                rb.AddForce(Vector3.down * 75, ForceMode.Acceleration);
                throttle = 0;
                rb.drag = 1;
            } else
            Flyspeed = maxspeed * throttle;
            Flyspeed = Mathf.Clamp(Flyspeed, 0.0f, maxspeed);
            earnedmoney = distancetrk.totalDistanceTraveled * 10f;
            upgmanager.upgmenu = false;
            

        }
        else
        {
            Flyspeed = 0;
            Yaw = 0;
            pitch = 0;
            roll = 0;
            throttle = 0;
            fuel = 0;
            upgmanager.OpenUpgMenu.gameObject.SetActive(true);
            upgmanager.CloseUpgMenu.gameObject.SetActive(true);

        }
        
        

       
        
    }







    





    //https://www.youtube.com/watch?v=7vAHo2B1zLc WATCH THIS!!!






    public void EndGame() {
        gamestart = false;
    continuebutton.SetActive(true);
    money = money + earnedmoney;
    distancetrk.totalDistanceTraveled = 0;
        transform.position = startpos;
        transform.rotation = orignialrotation;
    rb.velocity = UnityEngine.Vector3.zero;
    rb.angularVelocity = UnityEngine.Vector3.zero;
    
        rb.constraints = RigidbodyConstraints.FreezeAll;
    throttle = 0f;
        
        rb.constraints = RigidbodyConstraints.FreezeAll;
        transform.position = startpos;
        Flyspeed = 0;
        
    
    }
      

    
   
    
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("terrain"))
        {
            EndGame();
            
        }

        
    }
    public void ContinueGame()
    {
        gamestart = true;
        rb.drag = upgdrag;
        rb.constraints = RigidbodyConstraints.None;
        fuel = maxfuel;
        
       
       // upgmanager.Speedupg.interactable = false;
      //  upgmanager.Agilityupg.interactable = false;
      //  upgmanager.Fuelrefill.interactable = false;
        distancetrk.totalDistanceTraveled = 0;
        upgmanager.earnedmoneydisplay = string.Empty;
        earnedmoney = 0;
        Time.timeScale = 1f;
        rb.drag = upgmanager.playerrb.drag;
        continuebutton.SetActive(false);

    }
}
