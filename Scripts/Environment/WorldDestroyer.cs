using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldDestroyer : MonoBehaviour
{
    // Variable to store the name of the parent object.
    public string parentName;

    void Start()
    {
        // On start, store the name of this object's transform.
        parentName = transform.name;
        // Start the coroutine responsible for destroying this object.
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        // Wait for a predefined period (150 seconds in this case) before executing the next line of code.
        // This delay allows the game object to exist for some time before checking if it needs to be destroyed.
        yield return new WaitForSeconds(150);
        
        // Check if this object is a clone of a section.
        if (parentName == "Section(Clone)")
        {
            // If this object is indeed a cloned section, destroy it to clean up the game world.
            Destroy(gameObject);
        }
    }
}
