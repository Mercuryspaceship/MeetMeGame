using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DoorNameController : MonoBehaviour
{
    [SerializeField] private Text roomNameText;
    
    // Start is called before the first frame update
    void Start()
    {
        roomNameText.text = gameObject.name.Substring(4) + ":";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
