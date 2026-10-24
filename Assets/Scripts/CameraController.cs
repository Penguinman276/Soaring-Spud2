using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    [SerializeField] Transform[] pov;
    [SerializeField] float speed;

    private int index = 1;
    public Vector3 target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) index = 0;
        else if (Input.GetKeyDown(KeyCode.Alpha2)) index = 1;
        else if (Input.GetKeyDown(KeyCode.Alpha3)) index = 2;
        else if (Input.GetKeyDown(KeyCode.Alpha4)) index = 3;

       
    }

    private void FixedUpdate()
    {
        target = pov[index].position;

        transform.position = Vector3.MoveTowards(transform.position, target,Time.deltaTime * speed);
        transform.forward = pov[index].forward;
    }
}
