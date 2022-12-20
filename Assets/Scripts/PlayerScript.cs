using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : Photon.MonoBehaviour
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
        if (view.isMine)
        {
            playerCamera.SetActive(true);
            videoCanvas.SetActive(true);
            playerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            playerNameText.text = this.transform.GetComponent<PhotonView>().owner.NickName;
            playerNameText.color = Color.cyan;
        }
    }

    private void Update()
    {
        if (view.isMine)
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
            photonView.RPC("FlipTrue", PhotonTargets.AllBuffered);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            photonView.RPC("FlipFalse", PhotonTargets.AllBuffered);
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

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "stateDoor")
        {
            collider.gameObject.transform.GetChild(1).gameObject.SetActive(true);
            Debug.Log("COLLIDER STATE DOOR");
        }
        
        if (view.isMine)
        {
            
        }
    }
}