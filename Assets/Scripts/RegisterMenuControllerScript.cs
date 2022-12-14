using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RegisterMenuControllerScript : MonoBehaviour
{
    [SerializeField] private GameObject registerMenu;
    
    [SerializeField] private InputField userNameInput;

    [SerializeField] private InputField eMailInput;

    [SerializeField] private InputField passwordInput;

    [SerializeField] private InputField confirmPasswordInput;

    [SerializeField] private Text errorText;


    // Start is called before the first frame update
    void Start()
    {
        ResetMenu();
    }

    private bool UserNameIsValid()
    {
        String username = userNameInput.text;

        if (username.Length >= 5)
        {
            return true;
        }

        return false;
    }

    private bool UserExists()
    {
        String username = userNameInput.text;
        
        //TODO: Database call

        return false;
    }

    private bool EMailIsValid()
    {
        String emailAddress = eMailInput.text;
        
        if (emailAddress.Contains("@") && emailAddress.Length >= 10)
        {
            return true;
        }

        return false;
    }
    
    private bool EMailExists()
    {
        //TODO: database call

        return false;
    }

    private bool PasswordLengthIsOk()
    {
        if (((passwordInput.text).Length >= 8))
        {
            return true;
        }

        return false;
    }

    private bool PasswordsMatch()
    {
        if (passwordInput.text.Equals(confirmPasswordInput.text))
        {
            return true;
        }

        return false;
    }

    public void OnCLickOk()
    {
        if (!UserNameIsValid())
        {
            errorText.text = "Username is too short!\nPlease choose a username with at least 5 characters.";
        }
        else if (UserExists())
        {
            errorText.text = "User already exists!\nPlease choose another username.";
        }else if (!EMailIsValid())
        {
            errorText.text = "Please enter a valid E-Mail-Address!";
        }else if (EMailExists())
        {
            errorText.text = "This E-Mail-Address is already registered!\nPlease enter another E-Mail-Address.";
        }
        else if (!PasswordLengthIsOk())
        {
            errorText.text = "Password is too short!\nPlease choose a password with at least 8 characters.";
        }
        else if (!PasswordsMatch())
        {
            errorText.text = "Passwords don't match!";
        }
        else
        {
            //TODO: database call
            registerMenu.SetActive(false);
            ResetMenu();
        }
    }

    public void OnCLickBack()
    {
        registerMenu.SetActive(false);
        ResetMenu();
    }

    private void ResetMenu()
    {
        userNameInput.text = eMailInput.text = passwordInput.text = confirmPasswordInput.text = errorText.text = "";

    }
}