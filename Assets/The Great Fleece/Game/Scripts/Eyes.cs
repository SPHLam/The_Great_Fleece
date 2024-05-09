using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eyes : MonoBehaviour
{
    public GameObject _gameOverCutscene;
    // Detect Darren when he's in the zone
    private void OnTriggerEnter(Collider other)
    {
        // Check if the object collide is the player
        if (other.tag == "Player")
        {
            // Turn on Game Over scene
            _gameOverCutscene.SetActive(true);
        }
    }
}
