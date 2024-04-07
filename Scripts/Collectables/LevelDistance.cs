using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDistance : MonoBehaviour
{
    // Reference to the UI GameObject that displays the current distance traveled during gameplay.
    public GameObject disDisplay;
    // Reference to the UI GameObject that displays the distance traveled on the end screen or another relevant UI panel.
    public GameObject disEndDisplay;
    // Static variable to keep track of the total distance run.
    // Static so it can be easily accessed and modified from other scripts.
    public static int disRun;
    // Flag to control the addition of distance to prevent concurrent coroutine executions.
    public bool addingDis = false;
    // Delay between each increment of the distance run.
    public float disDelay = 0.35f;

    void Update()
    {
        // Check if the coroutine to add distance is not already running.
        if (!addingDis)
        {
            addingDis = true; // Set the flag to true to indicate the coroutine is running.
            StartCoroutine(AddingDis()); // Start the coroutine.
        }
    }

    IEnumerator AddingDis()
    {
        disRun += 1; // Increment the distance run by 1.
        // Update the text component of the disDisplay GameObject to show the current distance run.
        disDisplay.GetComponent<Text>().text = "" + disRun;
        // Similarly, update the text component of the disEndDisplay GameObject.
        disEndDisplay.GetComponent<Text>().text = "" + disRun;
        // Wait for the specified delay before allowing another increment.
        yield return new WaitForSeconds(disDelay);
        addingDis = false; // Reset the flag so the coroutine can be started again.
    }
}

