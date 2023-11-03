using System;
using UnityEngine;
public class BadScript : MonoBehaviour
{
    private Vector3 newPosition; // Contains randomised movement values of the object
    private bool canMove = true; //  Switch to determine whether the object is capable of moving

    public float maxX; // The farthest distance achievable along the X-axis
    public float maxY; // The farthest distance achievable along the Y-axis
    public float maxZ; // The farthest distance achievable along the Z-axis

    public int counter = 0; // Numeric value that keeps a record of the object's movement


    void Update()
    {
        if (Input.GetMouseButtonDown(0))     // Examines for clicks and initiates object movement in response to a click
        {
            DoTheMove();
        }
    }

    private void DoTheMove()
    {
        if (canMove)
        {
            // Generate random movement values within specified ranges
            // These randoms are movement range modifiers, providing random values either positive or negative
            newPosition = new Vector3
                (UnityEngine.Random.value > 0.5f ? UnityEngine.Random.Range(-maxX, maxX) : transform.position.x,  
                                      UnityEngine.Random.value > 0.5f ? UnityEngine.Random.Range(-maxY, maxY) : transform.position.y,  
                                      UnityEngine.Random.value > 0.5f ? UnityEngine.Random.Range(-maxZ, maxZ) : transform.position.z); 

            transform.position = newPosition;                  // This Adds Movement to the Object
            Debug.Log("We moved!");                                  // When movement is feasible, the message 'We moved!' will be shown in the console
            counter++;                                               // increase the number of times clicked for moves

            if (counter > 10)                                  //check number of times moved if over 10, stop moving
            {
                canMove = false;
            }
        }
        else
        {
            Debug.LogWarning("Can't move anymore!");                 //If moving is not possible "Can't move anymore!" will be displayed in the console            
        }
    }
}