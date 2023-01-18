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

    [SerializeField] private Text playerNameText;

    [SerializeField] private float movingSpeed = 5f;

    [SerializeField] private GameObject movingKeysInfo;

    [SerializeField] private GameObject chatKeysInfo;

    [SerializeField] private VideoCallScript videoCallScript;

    [SerializeField] private GameObject chatManager;

    [SerializeField] private PhotonChatManager photonChatManager;

    string otherPlayerName;

    private void Start()
    {
        if (view.IsMine)
        {
            gameObject.name = PhotonNetwork.LocalPlayer.NickName;

            playerCamera.SetActive(true);

            playerNameText.text = PhotonNetwork.LocalPlayer.NickName;

            movingKeysInfo.SetActive(true);
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
        if (!(Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W) ||
              Input.GetKey(KeyCode.S)))
        {
            float moveHorizontal = Input.GetAxisRaw(("Horizontal"));
            float moveVertical = Input.GetAxisRaw(("Vertical"));

            Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0) * (Time.deltaTime * movingSpeed);

            transform.position += movement;

            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                photonView.RPC("FlipTrue", RpcTarget.AllBuffered);
            }

            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                photonView.RPC("FlipFalse", RpcTarget.AllBuffered);
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) ||
                Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.DownArrow))
            {
                animator.SetBool("isMoving", true);
            }
            else
            {
                animator.SetBool("isMoving", false);
            }
        }

        if (videoCallScript.VideoCanvasIsActive())
        {
            if (Input.GetKeyUp(KeyCode.Y))
            {
                videoCallScript.ToggleCamera();
            }

            if (Input.GetKeyUp(KeyCode.X))
            {
                videoCallScript.ToogleMic();
            }
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
            if (col.gameObject.CompareTag("stateDoor") || col.gameObject.CompareTag("loginMenuDoor") ||
                col.gameObject.CompareTag("mainRoomDoor"))
            {
                col.gameObject.transform.Find("DoorPopUp").gameObject.SetActive(true);
            }

            if (col.gameObject.CompareTag("meetingRoom"))
            {
                videoCallScript.EnableVideoCall();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (view.IsMine)
        {
            if (col.gameObject.CompareTag("stateDoor") || col.gameObject.CompareTag("loginMenuDoor") ||
                col.gameObject.CompareTag("mainRoomDoor"))
            {
                col.gameObject.transform.Find("DoorPopUp").gameObject.SetActive(false);
            }

            if (col.gameObject.CompareTag("meetingRoom"))
            {
                videoCallScript.DisableVideoCall();
            }

            if (col.gameObject.CompareTag("player"))
            {
                DeactivateChat();
            }
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        gameObject.GetComponent<Rigidbody2D>().WakeUp();

        if (col.gameObject.CompareTag("player"))
        {
            otherPlayerName = col.gameObject.transform.GetComponent<PhotonView>().Owner.NickName;
            
            if (photonView.IsMine)
            {
                chatKeysInfo.SetActive(true);

                if (Input.GetKey(KeyCode.C))
                {
                    ActivateChat(otherPlayerName);
                    photonView.RPC("OpenChatWindow", RpcTarget.Others, col.gameObject.GetComponent<PhotonView>().ViewID);
                    Debug.Log("VIEW ID: " + col.gameObject.GetComponent<PhotonView>().ViewID);
                }
            }
        }
    }

    [PunRPC]
    private void OpenChatWindow(int targetPlayerViewID)
    {
        if (photonView.ViewID == targetPlayerViewID)
        {
            ActivateChat(otherPlayerName);
        }
    }

    public void ActivateChat(string otherPlayerName)
    {
        chatManager.SetActive(true);

        photonChatManager.SetPrivateReceiver(otherPlayerName);
        Debug.Log("Private receiver is: " + otherPlayerName);
    }

    public void DeactivateChat()
    {
        chatKeysInfo.SetActive(false);

        chatManager.SetActive(false);
    }
}