using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Windows.WebCam;

public class LoginMenuControllerScript : MonoBehaviour
{
    [SerializeField] private string versionName = "0.1";
    [SerializeField] private GameObject registerMenu;

    [SerializeField] private InputField eMailInput;
    [SerializeField] private InputField passwordInput;
    
    [SerializeField] private GameObject startButton;

    private String _defaultRoomName = "defaultRoom";
    [SerializeField] private byte maxPlayersPerRoom = 10;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
    }
    
    // Start is called before the first frame update
    private void Start()
    {
        // userNameMenu.SetActive(true);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    private void SetUserName()
    {
        // registerMenu.SetActive(false);
        PhotonNetwork.playerName = eMailInput.text;
        
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(_defaultRoomName, new RoomOptions() { MaxPlayers = maxPlayersPerRoom }, null);
    }
    
    private void JoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayersPerRoom;
        PhotonNetwork.JoinOrCreateRoom(_defaultRoomName, roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainRoom");
    }

    private bool UserExists()
    {
        String userName = eMailInput.text;
        
        //TODO: Database call

        return true;
    }

    private bool PasswordIsCorrect()
    {
        String password = passwordInput.text;
        
        //TODO: Database call
        
        return true;
    }

    public void OnLoginClicked()
    {
        if (UserExists() && PasswordIsCorrect())
        {
            SetUserName();
            JoinRoom();
        }
    }

    public void OnRegisterClicked()
    {
        registerMenu.SetActive(true);
    }
    
    
}