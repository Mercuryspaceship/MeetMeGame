using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterMenuControllerScript : MonoBehaviour
{
    [SerializeField] private InputField userNameInput;

    [SerializeField] private InputField eMailInput;

    [SerializeField] private InputField passwordInput;

    [SerializeField] private InputField confirmPasswordInput;

    [SerializeField] private InputField phoneNumberInput;

    [SerializeField] private Text errorText;

    
    // Start is called before the first frame update
    void Start()
    {
        errorText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    
}
