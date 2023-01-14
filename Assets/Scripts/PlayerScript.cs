using System;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviourPun
{
    [SerializeField] private PhotonView view;
    [SerializeField] private SpriteRenderer spriteRenderer;

    [SerializeField] private Animator animator;
    [SerializeField] private GameObject playerCamera;

    [SerializeField] private GameObject videoCanvas;

    [SerializeField] private Text playerNameText;
    
    [SerializeField] private float movingSpeed = 5f;

    private void Start()
    {
        if (view.IsMine)
        {
            playerCamera.SetActive(true);

            playerNameText.text = PhotonNetwork.LocalPlayer.NickName;
        }
        else
        {
            playerNameText.text = this.transform.GetComponent<PhotonView>().Owner.NickName;
            playerNameText.color = Color.cyan;
        }
    }

    private void Update()
    {
        if (view.IsMine)
        {
            CheckInput();
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    private void CheckInput()
    {
        float moveHorizontal = Input.GetAxisRaw(("Horizontal"));
        float moveVertical = Input.GetAxisRaw(("Vertical"));

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * (Time.deltaTime * movingSpeed);

        transform.position += movement;

        if (Input.GetKeyDown(KeyCode.A))
        {
            photonView.RPC("FlipTrue", RpcTarget.AllBuffered);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            photonView.RPC("FlipFalse", RpcTarget.AllBuffered);
        }
        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }
    }

    [PunRPC]
    private void FlipTrue()
    {
        spriteRenderer.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        spriteRenderer.flipX = false;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (view.IsMine)
        {
            if (col.gameObject.CompareTag("stateDoor")  || col.gameObject.CompareTag("loginMenuDoor") || col.gameObject.CompareTag("mainRoomDoor"))
            {
                col.gameObject.transform.Find("DoorPopUp").gameObject.SetActive(true);
            }

            if (col.gameObject.CompareTag("meetingRoom"))
            {
                videoCanvas.SetActive(true);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D col)
    {
        if (view.IsMine)
        {
            if (col.gameObject.CompareTag("stateDoor")  || col.gameObject.CompareTag("loginMenuDoor") || col.gameObject.CompareTag("mainRoomDoor"))
            {
                col.gameObject.transform.Find("DoorPopUp").gameObject.SetActive(false);
            }

            if (col.gameObject.CompareTag("meetingRoom"))
            {
                Destroy(videoCanvas);

                // Re-instantiate the videoCanvas GameObject
                videoCanvas = Instantiate(videoCanvas);
                videoCanvas.SetActive(false);
            }
        }
    }
    
}