/*
* Name: John Chirayil
* CGE401 - Assignment 5B
* File: LoseOnFall.cs
* Desc: The player will lose when the fall to the void.
* A message will appear to tell the player to restart the game
* by pressing R.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LoseOnFall : MonoBehaviour
{
    public float fallThreshold = -10f; // The Y position at which the player loses
    public Text loseText;              // UI Text component for displaying the lose message
    private FinishLineTriggerZone finishLine;  // Reference to the FinishLineTriggerZone script
    private bool hasLost = false;      // Flag to check if the player has lost

    // Start is called before the first frame update
    private void Start()
    {
        // Ensure the lose message is hidden at the start
        if (loseText != null)
        {
            loseText.enabled = false;
        }

        // Find the FinishLineTriggerZone script to access hasWon
        finishLine = FindObjectOfType<FinishLineTriggerZone>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check if the player has fallen below the threshold
        if (transform.position.y < fallThreshold && !hasLost && (finishLine == null || !finishLine.hasWon))
        {
            hasLost = true;

            // Display the lose message
            if (loseText != null)
            {
                loseText.text = "You Lose! Press R to Try Again!";
                loseText.enabled = true;
            }
        }

        // Allow the player to restart the level if they've lost and pressed "R"
        if (hasLost || (finishLine != null && finishLine.hasWon) && Input.GetKeyDown(KeyCode.R))
        {
            if (loseText != null) loseText.enabled = false;
            if (finishLine != null && finishLine.winText != null) finishLine.winText.enabled = false;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
