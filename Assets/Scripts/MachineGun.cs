using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class MachineGun : MonoBehaviour
{
    public GameObject tracerPrefab;
    public Transform muzzle;
    public float tracerSpeed = 300f;
    public float tracerLifetime = 2.5f;

    public float range;
    public float firerate;

    private float hangtime;

   
    // Start is called before the first frame update
    void Start()
    {
        
    }
    System.Collections.IEnumerator MoveTracer(
    GameObject tracer, Vector3 direction)
    {
        float timer = 0f;

        while(timer < tracerLifetime && tracer != null)
        {
            tracer.transform.position += direction * tracerSpeed * Time.deltaTime;
            
            timer += Time.deltaTime;

            yield return null;
        }

        if (tracer != null)
        {
            Destroy(tracer);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= hangtime)
        {
            Squeeze();
            hangtime = Time.time + firerate;
        }
    }

    void Squeeze()
    {
        GameObject tracer = Instantiate(tracerPrefab, muzzle.position, Quaternion.LookRotation(muzzle.forward));

        StartCoroutine(MoveTracer(tracer, muzzle.forward));

        RaycastHit hit;

        if (UnityEngine.Physics.Raycast(transform.position, transform.forward, out hit, range)) 
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Hit enemy");
            }
        }
       
    }
    
}
