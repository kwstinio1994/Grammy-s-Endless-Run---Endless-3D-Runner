using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // Initial forward movement speed of the player
    public float moveSpeed = 5;
    // Speed at which the player can move left or right
    public float leftRightSpeed = 5;
    // Amount by which the move speed increases over time
    public float speedIncreaseOverTime = 0.05f;
    // Interval in seconds at which the speed increase will occur
    public float speedIncreaseInterval = 20;
    // Keeps track of the time since the last speed increase
    private float timeSinceLastIncrease = 0;

    // Static variable to control if the player can move
    static public bool canMove = false;
    // Flags to control the jumping state of the player
    public bool isJumping = false;
    public bool comingDown = false;
    // Reference to the player's GameObject for accessing components
    public GameObject playerObject;

    void Update()
    {
        // Constantly moves the player forward at the current move speed
        transform.Translate(Vector3.forward * Time.deltaTime * moveSpeed, Space.World);

        // Checks and updates the move speed at defined intervals
        timeSinceLastIncrease += Time.deltaTime;
        if (timeSinceLastIncrease >= speedIncreaseInterval)
        {
            moveSpeed += speedIncreaseOverTime; // Increase move speed
            timeSinceLastIncrease = 0; // Reset the timer
        }

        // Checks if player movement is enabled
        if (canMove)
        {
            // Left movement
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                // Ensures the player doesn't move out of the level boundary
                if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
                {
                    // Moves the player left
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed);
                }
            }

            // Right movement
            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                // Ensures the player doesn't move out of the level boundary
                if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
                {
                    // Moves the player right
                    transform.Translate(Vector3.left * Time.deltaTime * leftRightSpeed * -1);
                }
            }

            // Jumping logic
            if (!isJumping && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space)))
            {
                // Initiates jumping
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(JumpSequence());
            }
        }

        // Handles the jumping and coming down mechanics
        if (isJumping)
        {
            if (!comingDown)
            {
                // Moves the player up
                transform.Translate(Vector3.up * Time.deltaTime * 1.25f, Space.World);
            }
            else
            {
                // Moves the player down
                transform.Translate(Vector3.up * Time.deltaTime * -1.25f, Space.World);
            }
        }
    }

    // Coroutine to handle the jump sequence
    IEnumerator JumpSequence()
    {
        // Waits for a set duration before starting to come down
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        // Waits for another set duration before ending the jump
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown = false;
        // Resets the player's animation to running
        playerObject.GetComponent<Animator>().Play("Run");
    }
}
