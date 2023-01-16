using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;

    [SerializeField] private String roomName = "MainRoom";
    
    private void Awake()
    {
        roomName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;
        
        if (PhotonNetwork.IsConnected && PhotonNetwork.InRoom)
        {
            SpawnPlayer();
        }
    }
    
    public override void OnConnectedToMaster(){
        Debug.Log("002: Connected to MASTER");
        
        JoinRoom();
    }

    private void JoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("002: Joined the ROOM: " + roomName);

        SpawnPlayer();
    }

    public void SpawnPlayer()
    {
        Vector3 playerPosition;
        
        if (roomName.Equals("MainRoom") && PhotonNetwork.LocalPlayer.CustomProperties["playerPosition"] != null)
        {
            playerPosition = (Vector3)PhotonNetwork.LocalPlayer.CustomProperties["playerPosition"];
            
            Debug.Log("PLAYER POSITION " + playerPosition);

            PhotonNetwork.LocalPlayer.CustomProperties["playerPosition"] = null;
        }
        else
        {
            Debug.Log("NO PLAYER POSITION ");
            
            playerPosition = GameObject.Find("MainDoor").transform.position;
        }

        PhotonNetwork.Instantiate(playerPrefab.name,
            new Vector3(playerPosition.x, playerPosition.y -1.0f, 5),
            Quaternion.identity, 0);
    }

}
