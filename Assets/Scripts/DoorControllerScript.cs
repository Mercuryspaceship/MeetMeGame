using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            
            
        }
        else if(door.CompareTag("stateDoor"))
        {
          
        }
      
    }
    
    public void OnClickNo()
    {
        Debug.Log("DOOR NO");
        door.transform.Find("DoorPopUp").gameObject.SetActive(false);
    }
}
