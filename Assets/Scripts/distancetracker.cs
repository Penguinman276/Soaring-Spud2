using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distancetracker : MonoBehaviour
{
    public float totalDistanceTraveled = 0f;
    private Vector3 previousPosition;
    public float distancefromstart;
    public Transform start;

    void Start()
    {
        distancefromstart = 0f;
        // Initialize the previous position at the start of the game
        previousPosition = transform.position;
    }

    void Update()
    {
        distancefromstart = Vector3.Distance(start.transform.position, transform.position);
        // Calculate the distance moved since the last frame
        float distanceThisFrame = Vector3.Distance(previousPosition, transform.position);

        // Add it to our total
        totalDistanceTraveled += distanceThisFrame;

        // Update the previous position for the next frame
        previousPosition = transform.position;
    }
}
