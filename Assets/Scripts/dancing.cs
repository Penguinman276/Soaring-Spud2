using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dancing : MonoBehaviour
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
    public float m;
    public float ground;
    public float thrust;
    public float pitchrate;
    public float rollrate;
    public float stabilizeCoefficent;
    public float stabilizes;
    public float trueHeading;
    public float rudderArea;
    public float pitch;
    public float roll;
    public float yaw;
    public float maxAngle = 179f;
    public float minAngle = 1f;
    public Transform target;
    public float rotStiffness = 10f;
    public float damping = 2f;
    // Start is called before the first frame update
    void Start()
    {
        ground = 0f;
        thrust = 0.000005f;
        liftingArea = 1;
        crosssectArea = 1;
        rudderArea = 0.1f;

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        var localVelocity = transform.InverseTransformDirection(rb.velocity);
        AoA =
        Lift = liftCoefficent * dynamicPressure * liftingArea;
        Drag = dragCoefficent * dynamicPressure * crosssectArea;
        stabilizes = stabilizeCoefficent * dynamicPressure * rudderArea;
        Weight = m * -9.81f;
        dynamicPressure = 0.5f * airDensity * Velo * 2;
        airDensity = 1.224f - (0.000109f * altitude);
        liftCoefficent = (2 * 3.14f) * AoA;
        stabilizeCoefficent = (2 * 3.14f) * Input.compass.trueHeading;
        rb.mass = m;

        Velo = rb.velocity.magnitude;
        altitude = ground + transform.position.y;
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddRelativeForce(UnityEngine.Vector3.up * thrust);
        }

        UnityEngine.Quaternion spudorientation = rb.rotation;
        UnityEngine.Quaternion targetrotation = UnityEngine.Quaternion.LookRotation(target.position - rb.position);
        //UnityEngine.Vector3 pitch = spudorientation * transform.up;
        //UnityEngine.Vector3 roll = spudorientation * transform.right;
        UnityEngine.Quaternion rotationDifference = UnityEngine.Quaternion.Inverse(spudorientation) * targetrotation;
        if (rotationDifference.w < 0)
        {
            rotationDifference = new UnityEngine.Quaternion(-rotationDifference.x, -rotationDifference.y, -rotationDifference.z, -rotationDifference.w);
        }
        UnityEngine.Vector3 torqueRequest = new UnityEngine.Vector3(rotationDifference.x, rotationDifference.y, rotationDifference.z) * rotStiffness;
        // UnityEngine.Quaternion deltaRoll = UnityEngine.Quaternion.AngleAxis(horizontal * Time.deltaTime * rollrate, roll);
        // UnityEngine.Quaternion deltaPitch = UnityEngine.Quaternion.AngleAxis(vertical * Time.deltaTime * pitchrate, pitch);
        UnityEngine.Vector3 angularVelocityError = rb.angularVelocity * -damping;
        UnityEngine.Vector3 totalTorque = torqueRequest + angularVelocityError;
        //UnityEngine.Quaternion deltaRotation = deltaPitch * deltaRoll;

        pitchrate = 1f;
        rollrate = 1f;
        //rb.AddRelativeTorque(vertical * transform.up * pitchrate, ForceMode.Acceleration);
        //rb.AddRelativeTorque(-horizontal * transform.right * rollrate, ForceMode.Acceleration);
        rb.AddRelativeTorque(totalTorque, ForceMode.Force);

    }
    public void EndGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(1);
    }
}
