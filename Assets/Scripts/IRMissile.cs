using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IRMissile : MonoBehaviour
{
    public float speed = 30f;
    public float acceleration = 15f;
    public float turnSpeed = 90f;
    
    public Transform target;
    public Rigidbody rb;
    public Collider Collider;

    public bool launched;
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.F)) 
        {
            launched = true;
        }
        
        // Accelerate the missile
        speed += acceleration * Time.deltaTime;

        if (launched == true)
        {
            if (target != null)
            {
                Vector3 direction = target.position - transform.position;

                Quaternion targetRotation =
                    Quaternion.LookRotation(direction);

                transform.rotation = Quaternion.RotateTowards(
                    transform.rotation,
                    targetRotation,
                    turnSpeed * Time.deltaTime
                );
            }

            // Move forward
            transform.position +=
                transform.forward * speed * Time.deltaTime;

            if (Collider.CompareTag("Enemy"))
             {
                Debug.Log("hit enemy");
            }

        }// Turn toward the target
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

 
    
    // Update is called once per frame
 
   
    

   
}
