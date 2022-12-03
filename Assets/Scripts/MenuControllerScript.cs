using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuControllerScript : MonoBehaviour
{
    [SerializeField] private string versionName = "0.1";
    [SerializeField] private GameObject connectMenu;
    [SerializeField] private GameObject userNameMenu;

    [SerializeField] private InputField createInput;
    [SerializeField] private InputField joinButton;
    [SerializeField] private InputField userNameInput;

    [SerializeField] private GameObject startButton;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings(versionName);
    }

    private void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    // Start is called before the first frame update
    private void Start()
    {
        userNameMenu.SetActive(true);
    }

    public void OnUserNameChanged()
    {
        if (userNameInput.text.Length >= 3)
        {
            startButton.SetActive(true);
        }
        else
        {
            startButton.SetActive(false);
        }
    }

    public void SetUserName()
    {
        userNameMenu.SetActive(false);
        PhotonNetwork.playerName = userNameInput.text;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.text, new RoomOptions() { MaxPlayers = 5 }, null);
    }
    
    public void JoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 5;
        PhotonNetwork.JoinOrCreateRoom(joinButton.text, roomOptions, TypedLobby.Default);
    }

    private void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("MainRoom");
    }
}