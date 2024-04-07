using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    // Public variable to control the speed of rotation. Can be adjusted in the Unity Editor.
    public int rotateSpeed = 1;

    void Update()
    {
        // Rotate the GameObject this script is attached to.
        // The rotation is around the y-axis (up) at the speed specified by rotateSpeed.
        // The rotation is applied relative to the world space, ensuring consistent rotation direction
        // regardless of the object's local orientation.
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
}

