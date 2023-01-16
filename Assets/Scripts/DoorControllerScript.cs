
using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using Photon.Realtime;

public class DoorControllerScript : MonoBehaviourPunCallbacks
{
    [SerializeField] private GameObject door;

    public void OnClickYes()
    {
        if(door.CompareTag("loginMenuDoor"))
        {
            SceneManager.LoadScene("LoginMenu");
            PhotonNetwork.Disconnect();
        }
        else if (door.CompareTag("mainRoomDoor"))
        {
            PhotonNetwork.LeaveRoom();
            SceneManager.LoadScene("MainRoom");
        }
        else if(door.CompareTag("stateDoor"))
        {
                StorePositionOfPlayer();
            
                PhotonNetwork.LeaveRoom();
                SceneManager.LoadScene(door.name.Substring(4));
        }
      
    }
    
    public void OnClickNo()
    {
        Debug.Log("DOOR NO");
        door.transform.Find("DoorPopUp").gameObject.SetActive(false);
    }

    private void StorePositionOfPlayer()
    {
        Vector3 playerPosition = GameObject.Find(PhotonNetwork.LocalPlayer.NickName).transform.position;
        ExitGames.Client.Photon.Hashtable customProperties = new ExitGames.Client.Photon.Hashtable();
        customProperties.Add("playerPosition", playerPosition);
        PhotonNetwork.LocalPlayer.SetCustomProperties(customProperties);
    }
}
