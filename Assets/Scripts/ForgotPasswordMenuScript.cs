using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ForgotPasswordMenuScript : MonoBehaviour
{
    [SerializeField] private GameObject forgotPasswordMenu;

    [SerializeField] private InputField emailInput;

    [SerializeField] private InputField newPasswordInput;
    
    [SerializeField] private InputField confirmNewPasswordInput;

    [SerializeField] private Text errorText;
    
    // Start is called before the first frame update
    void Start()
    {
        ResetMenu();
    }

    private bool EMailIsValid()
    {
        String emailAddress = emailInput.text;
        
        if (emailAddress.Contains("@") && emailAddress.Length >= 10)
        {
            return true;
        }

        return false;
    }
    
    private bool EMailExists()
    {
        //TODO: database call

        return true;
    }

    private bool PasswordLengthIsOk()
    {
        if (((newPasswordInput.text).Length >= 8))
        {
            return true;
        }

        return false;
    }

    private bool PasswordsMatch()
    {
        if (newPasswordInput.text.Contains(confirmNewPasswordInput.text))
        {
            return true;
        }

        return false;
    }
    
    public void OnCLickOk()
    {
        if (!EMailIsValid())
        {
            errorText.text = "Please enter a valid E-Mail-Address!";
        }else if (!EMailExists())
        {
            errorText.text = "This E-Mail-Address is not registered!\nPlease enter another E-Mail-Address.";
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
            forgotPasswordMenu.SetActive(false);
            ResetMenu();
        }
    }
    
    public void OnCLickBack()
    {
        forgotPasswordMenu.SetActive(false);
        ResetMenu();
    }
    private void ResetMenu()
    {
        emailInput.text = newPasswordInput.text = confirmNewPasswordInput.text = errorText.text = "";

    }
}
