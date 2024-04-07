using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableControl : MonoBehaviour
{
    // Static variable to keep track of the total number of coins collected.
    // Static so it can be easily accessed and modified from other scripts.
    public static int coinCount;

    // Reference to the UI GameObject that displays the current coin count during gameplay.
    public GameObject coinCountDisplay;

    // Reference to the UI GameObject that displays the coin count on the end screen or another relevant UI panel.
    public GameObject coinEndDisplay;

    void Update()
    {
        // Every frame, update the text component of the coinCountDisplay GameObject to show the current coin count.
        coinCountDisplay.GetComponent<Text>().text = "" + coinCount;

        // Similarly, update the text component of the coinEndDisplay GameObject.
        coinEndDisplay.GetComponent<Text>().text = "" + coinCount;
    }
}
