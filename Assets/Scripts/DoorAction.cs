using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DoorAction : MonoBehaviour
{
    private bool collider = false;
    public GameObject popupMenu; // Reference to the popup menu game object
    public GameObject player;

    private void Start()
    {
        popupMenu.SetActive(false);
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            popupMenu.SetActive(true);
            Debug.Log("collider!!!");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "player")
        {
            popupMenu.SetActive(false);
            collider = false;
        }
        
    }
    
    
}

