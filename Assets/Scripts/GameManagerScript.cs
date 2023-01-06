using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject gameCanvas;
    [SerializeField] private GameObject sceneCamera;

    public void start()
    {
       
    }
    private void Awake()
    {
        gameCanvas.SetActive(true);
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
