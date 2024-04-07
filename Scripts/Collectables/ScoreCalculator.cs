using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCalculator : MonoBehaviour
{
    // Reference to the UI GameObject that displays the current score during gameplay.
    public GameObject scoreDisplay;
    // Reference to the UI GameObject that displays the score on the end screen or another relevant UI panel.
    public GameObject scoreEndDisplay;
    // Integer to keep track of the score.
    public int score;
    // Flag to prevent concurrent score calculations.
    public bool addingScore = false;
    // Delay between each score update.
    public float disDelay = 0.35f;

    void Update()
    {
        // Check if the coroutine to add score is not already running.
        if (!addingScore)
        {
            addingScore = true; // Set the flag to true to indicate the coroutine is running.
            StartCoroutine(AddingScore()); // Start the coroutine for adding score.
        }
    }

    IEnumerator AddingScore()
    {
        // Increment the score by 1, plus a bonus calculated from the number of coins collected
        // and the distance run. This encourages collecting coins and running further.
        score += 1 + (CollectableControl.coinCount * LevelDistance.disRun);

        // Update the text component of the scoreDisplay GameObject to show the current score.
        scoreDisplay.GetComponent<Text>().text = "" + score;

        // Similarly, update the text component of the scoreEndDisplay GameObject.
        // This ensures that the final score is ready to be displayed, typically at the end of a level or game.
        scoreEndDisplay.GetComponent<Text>().text = "" + score;

        // Wait for the specified delay before allowing another score update.
        yield return new WaitForSeconds(disDelay);

        addingScore = false; // Reset the flag so the coroutine can be started again.
    }
}
