using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinState : MonoBehaviour
{
    public GameObject winCutscene;
    private void OnTriggerEnter(Collider other)
    {
        // Check for Darren
        if (other.tag == "Player")
        {
            // Check game manager for key
            // trigger win cutscene
            // else print out a message notify the Player must have the key
            if (GameManager.GameManagerInstance.haveCard == true)
            {
                winCutscene.SetActive(true);
            }        
        }
    }
}
