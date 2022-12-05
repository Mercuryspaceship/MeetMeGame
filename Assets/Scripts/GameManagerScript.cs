using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManagerScript : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject gameCanvas;
    public GameObject sceneCamera;

    private void Awake()
    {
        gameCanvas.SetActive(true);
    }

    public void SpawnPlayer()
    {
        float randomValue = Random.Range(-1f, 1f);

        PhotonNetwork.Instantiate(playerPrefab.name,
            new Vector3(0, 0, 5),
            Quaternion.identity, 0);
        gameCanvas.SetActive(false);
        sceneCamera.SetActive(false);
    }

}
