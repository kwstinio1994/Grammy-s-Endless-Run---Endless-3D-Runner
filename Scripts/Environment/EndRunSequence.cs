using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRunSequence : MonoBehaviour
{
    // References to GameObjects in the UI representing live coins, distance, and score
    public GameObject liveCoins;
    public GameObject liveDis;
    public GameObject liveScore;
    // Reference to the end screen GameObject, which presumably shows final scores or messages
    public GameObject endScreen;
    // Reference to a GameObject that is likely used for a fade-out effect
    public GameObject fadeOut;

    void Start()
    {
        // Start the end-of-run sequence coroutine
        StartCoroutine(EndSequence());
    }

    IEnumerator EndSequence()
    {
        // Wait for 3 seconds before starting the sequence
        yield return new WaitForSeconds(3);
        // Deactivate the live coins, distance, and score UI elements
        liveCoins.SetActive(false);
        liveDis.SetActive(false);
        liveScore.SetActive(false);
        // Activate the end screen to show final scores or messages
        endScreen.SetActive(true);
        // Wait for an additional 2 seconds with the end screen active
        yield return new WaitForSeconds(2);
        // Activate the fade-out effect
        fadeOut.SetActive(true);
        // Wait for another second during the fade-out before proceeding
        yield return new WaitForSeconds(1);
        // Load the scene at index 0, typically the main menu or the start of the game
        SceneManager.LoadScene(0);
    }
}
