using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorNameController : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Text roomNameText;

    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("mainDoor"))
        {
            messageText.text = "Logout and go to Login Menu?";
            roomNameText.text = "";
        }
        else if (gameObject.CompareTag("stateDoor"))
        {
            roomNameText.text = gameObject.name.Substring(4);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
