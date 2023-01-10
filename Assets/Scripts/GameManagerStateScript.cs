using System;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class GameManagerStateScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject sceneCamera;

    [SerializeField] private String roomName = "BerlinRoom";
    private byte maxPlayersPerRoom = 10;
    
    private void Awake()
    {
        
    }
    
    public override void OnConnectedToMaster(){
        Debug.Log("003: Connected to MASTER");
        
        JoinRoom();
    }

    private void JoinRoom()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = maxPlayersPerRoom;
        PhotonNetwork.JoinOrCreateRoom(roomName, roomOptions, TypedLobby.Default);
    }
    
    public override void OnJoinedRoom()
    {
        Debug.Log("003: Joined the ROOM: " + roomName);

        SpawnPlayer();
    }

    public void SpawnPlayer()
    {

        PhotonNetwork.Instantiate(playerPrefab.name,
            new Vector3(1.6f, 13.2f, 5),
            Quaternion.identity, 0);
        gameCanvas.SetActive(false);
        sceneCamera.SetActive(false);
    }

}
