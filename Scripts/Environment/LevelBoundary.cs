using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelBoundary : MonoBehaviour
{
    // Static variables to define the left and right boundaries of the level.
    // Static so they can be accessed from other scripts without needing a reference to an instance of LevelBoundary.
    public static float leftSide = -3.5f;
    public static float rightSide = 3.5f;

    // Internal instance variables to hold the same values as the static variables.
    // These can be used for non-static operations or to be displayed in the Unity Inspector.
    public float internalLeft;
    public float internalRight;

    void Update()
    {
        // Update the internal variables each frame to match the static variables.
        // This is useful if the static values might change and you want the changes
        // to be reflected in the instance variables for any reason, such as debugging or visual representation in the Unity Inspector.
        internalLeft = leftSide;
        internalRight = rightSide;
    }
}
