/*
* Name: John Chirayil
* CGE401 - Assignment 5B
* File: FinishLineTriggerZone.cs
* Desc: This code activates the trigger zone 
* for the win condition. A text will display
* after the player collides with the trigger zone.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FinishLineTriggerZone : MonoBehaviour
{
    public Text winText;             // UI Text component for displaying the win message
    public bool hasWon = false;     // Flag to check if the player has won
    public static FinishLineTriggerZone instance;

    // Start is called before the first frame update
    private void Start()
    {
        // Ensure the win message is hidden at the start
        if (winText != null)
        {
            winText.enabled = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player entered the trigger zone
        if (other.CompareTag("Player") && !hasWon)
        {
            hasWon = true;

            // Display the win message
            if (winText != null)
            {
                winText.text = "You Win! Press R to Play Again!";
                winText.enabled = true;
            }
        }
    }

    // Update is called once per frame
    private void Update()
    {
        // Allow the player to restart the level if they've won and pressed "R"
        if (hasWon && Input.GetKeyDown(KeyCode.R))
        {
            hasWon = false;  // Reset the win status for the next round
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

}
