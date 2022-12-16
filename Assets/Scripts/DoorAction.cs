using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorAction : MonoBehaviour
{
    public GameObject popupMenu; // Reference to the popup menu game object

    private void Start()
    {
        popupMenu.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            popupMenu.SetActive(true);
            TransformPosition();
            Debug.Log("collider!!!");
        }
    }

    private void TransformPosition()
    {
        // Get the current position of the game object
        Vector3 currentPosition = gameObject.transform.position;

        // Modify the position of the game object
        popupMenu.transform.position = new Vector3(currentPosition.x + 1, currentPosition.y + 1, currentPosition.z);
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            popupMenu.SetActive(false);
        }
        
    }
    
    
}

