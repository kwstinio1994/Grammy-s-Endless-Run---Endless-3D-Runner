using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour
{
    // Array of GameObjects representing different sections of the level that can be generated.
    public GameObject[] section;
    // The z-axis position where the next section should be instantiated.
    public int zPos = 0;
    // Flag to control the generation of the next section to avoid generating multiple sections at once.
    public bool creatingSection = false;
    // Variable to store the index of the section to be generated.
    public int secNum;

    void Update()
    {
        // Check if a section is not currently being created
        if (!creatingSection)
        {
            creatingSection = true; // Set the flag to true to indicate a section is now being created
            StartCoroutine(GenerateSection()); // Start the coroutine to generate a section
        }
    }

    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 6); // Randomly select one of the sections. Assumes there are 6 different types.
        // Instantiate the selected section at the current z position with no rotation (Quaternion.identity)
        Instantiate(section[secNum], new Vector3(0, 0, zPos), Quaternion.identity);
        zPos += 60; // Move the z position forward for the next section. Assuming that each section is 60 units long.
        yield return new WaitForSeconds(0.5f); // Wait for 0.5 seconds before allowing the next section to be created.
        creatingSection = false; // Reset the flag so the next section can be generated.
    }
}

