using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStarter : MonoBehaviour
{
    // References to GameObjects that represent the countdown numbers and the 'Go' signal.
    public GameObject countDown3;
    public GameObject countDown2;
    public GameObject countDown1;
    public GameObject countDownGo;
    // Reference to a GameObject that might be used to represent a fade-in effect at the start.
    public GameObject fadeIn;
    // Audio sources for the 'ready' countdown sounds and the final 'go' sound.
    public AudioSource readyFX;
    public AudioSource goFX;

    void Start()
    {
        // Begin the countdown sequence when the level starts.
        StartCoroutine(CountSequence());
    }

    IEnumerator CountSequence()
    {
        // Initial delay before the countdown starts.
        yield return new WaitForSeconds(1.5f);
        // Activate the '3' GameObject and play the ready sound effect.
        countDown3.SetActive(true);
        readyFX.Play();

        // Wait for a second then proceed to the next countdown number.
        yield return new WaitForSeconds(1);
        countDown3.SetActive(false); // It seems it was forgotten to deactivate the previous countdown GameObject.
        countDown2.SetActive(true);
        readyFX.Play();

        // Wait for another second for '2', then show '1'.
        yield return new WaitForSeconds(1);
        countDown2.SetActive(false); // Similarly, deactivating the previous number.
        countDown1.SetActive(true);
        readyFX.Play();

        // Final wait before showing 'Go' and enabling player movement.
        yield return new WaitForSeconds(1);
        countDown1.SetActive(false); // Deactivating the '1' countdown GameObject.
        countDownGo.SetActive(true);
        goFX.Play();

        // Enable player movement at the end of the countdown.
        PlayerMove.canMove = true;
    }
}

