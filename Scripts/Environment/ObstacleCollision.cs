using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    // Reference to the player GameObject to disable movement on collision.
    public GameObject thePlayer;
    // Reference to the character model to play the stumble animation.
    public GameObject charModel;
    // AudioSource component that plays a crash sound upon collision.
    public AudioSource crashThud;
    // Main camera GameObject, presumably to trigger camera animations.
    public GameObject mainCam;
    // Level control GameObject to manage gameplay state changes upon collision.
    public GameObject levelControl;

    // This method is called when another collider makes contact with this object's collider.
    void OnTriggerEnter(Collider other)
    {
        // Disable the collider component to prevent multiple triggers.
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        // Disable the player's movement script to stop the player.
        thePlayer.GetComponent<PlayerMove>().enabled = false;
        // Play the 'Stumble Backwards' animation for the character model.
        charModel.GetComponent<Animator>().Play("Stumble Backwards");
        // Disable level distance tracking, likely stopping level progress measurement.
        levelControl.GetComponent<LevelDistance>().enabled = false;
        // Disable the score calculator, stopping score accumulation.
        levelControl.GetComponent<ScoreCalculator>().enabled = false;
        // Play the sound effect for the crash.
        crashThud.Play();
        // Enable the main camera's animator, possibly to trigger a specific camera movement or effect.
        mainCam.GetComponent<Animator>().enabled = true;
        // Enable the EndRunSequence script to initiate the end of the run sequence.
        levelControl.GetComponent<EndRunSequence>().enabled = true;
    }
}
