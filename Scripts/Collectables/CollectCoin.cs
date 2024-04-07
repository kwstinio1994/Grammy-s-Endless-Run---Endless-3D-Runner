using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectCoin : MonoBehaviour
{
    // Reference to the AudioSource component that will play the coin collection sound effect.
    public AudioSource coinFX;

    // This method is called when another collider enters the trigger collider attached to this GameObject.
    void OnTriggerEnter(Collider other)
    {
        // Play the coin collection sound effect.
        coinFX.Play();

        // Increment the static coin count variable in the CollectableControl script by 1.
        CollectableControl.coinCount += 1;

        // Deactivate this coin GameObject, effectively "collecting" it and removing it from the scene.
        this.gameObject.SetActive(false);
    }
}

