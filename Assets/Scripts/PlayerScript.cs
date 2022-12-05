using System;
using System.Collections;
using System.Collections.Generic;
using ExitGames.Demos.DemoAnimator;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : Photon.MonoBehaviour
{
    public PhotonView _photonView;
    public Rigidbody2D _rigidBody;
    public SpriteRenderer _spriteRenderer;

    public Animator animator;
    public GameObject playerCamera;

    public Text playerNameText;


    public bool IsGrounded = false;
    public float movingSpeed = 5f;
    public float JumpForce;


    private void Start()
    {
        /*
        _photonView = GetComponent<PhotonView>(); 
        _rigidBody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        */

        if (_photonView.isMine)
        {
            playerCamera.SetActive(true);
            playerNameText.text = PhotonNetwork.playerName;
        }
        else
        {
            playerNameText.text = this.transform.GetComponent<PhotonView>().owner.NickName;
            // playerNameText.color = Color.cyan;
        }
    }

    private void Update()
    {
        if (_photonView.isMine)
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
        _spriteRenderer.flipX = true;
    }

    [PunRPC]
    private void FlipFalse()
    {
        _spriteRenderer.flipX = false;
    }
}