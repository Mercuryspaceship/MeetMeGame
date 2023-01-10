using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject door;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickYes()
    {
        if(door.CompareTag("mainDoor"))
        {
            Debug.Log("MAIN DOOR YES");

            SceneManager.LoadScene("LoginMenu");
            PhotonNetwork.Disconnect();
        }
        else if(door.CompareTag("stateDoor"))
        {
            if (door.name.Contains("Berlin"))
            {
                PhotonNetwork.LoadLevel("Berlin");
                Debug.Log("Berlin");
            }
        }
      
    }
    
    public void OnClickNo()
    {
        Debug.Log("DOOR NO");
        door.transform.Find("DoorPopUp").gameObject.SetActive(false);
    }
}
