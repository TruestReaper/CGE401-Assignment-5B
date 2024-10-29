/*
* Name: John Chirayil
* CGE401 - Assignment 5B
* File: MoveTarget.cs
* Desc: Moves the target vertically and horizontally
*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTarget : MonoBehaviour
{
    public float speed = 2.0f;       // Speed of the movement
    public float distance = 2.0f;    // Distance the target will move from its original position
    public bool moveVertically = true; // True for up-down, false for left-right
    public bool moveNegativeDirection = false; // True for moving downward or leftward initially

    private Vector3 startPosition;

    // Start is called before the first frame update
    void Start()
    {
        // Store the starting position
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveVertically)
        {
            // Move the target up and down
            float offset = startPosition.y + Mathf.PingPong(Time.time * speed, Mathf.Abs(distance)) - (distance / 2);
            float newY = startPosition.y + (moveNegativeDirection ? -offset : offset);
            transform.position = new Vector3(startPosition.x, newY, startPosition.z);
        }
        else
        {
            // Move the target left and right
            float offset = startPosition.x + Mathf.PingPong(Time.time * speed, Mathf.Abs(distance)) - (distance / 2);
            float newX = startPosition.x + (moveNegativeDirection ? -offset : offset);
            transform.position = new Vector3(newX, startPosition.y, startPosition.z);
        }
    }
}
