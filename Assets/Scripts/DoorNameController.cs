using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorNameController : MonoBehaviour
{
    [SerializeField] private Text messageText;
    [SerializeField] private Text roomNameText;
    [SerializeField] private GameObject doorNameText;
    // Start is called before the first frame update
    void Start()
    {
        if (gameObject.CompareTag("loginMenuDoor"))
        {
            messageText.text = "Logout and go to Login Menu?";
            roomNameText.text = "";
            doorNameText.GetComponent<TextMeshProUGUI>().text = "Logout";
        }
        else if (gameObject.CompareTag("mainRoomDoor"))
        {
            roomNameText.text = "Go to Main Room?";
            doorNameText.GetComponent<TextMeshProUGUI>().text = "Main room";
        }
        else if (gameObject.CompareTag("stateDoor"))
        {
            roomNameText.text = gameObject.name.Substring(4);
            doorNameText.GetComponent<TextMeshProUGUI>().text = gameObject.name.Substring(4);
        } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
