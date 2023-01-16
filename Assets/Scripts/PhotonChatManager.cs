using System.Collections;
using System.Collections.Generic;
using ExitGames.Client.Photon;
using Photon.Chat;
using Photon.Pun;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class PhotonChatManager : MonoBehaviour, IChatClientListener
{
    private ChatClient _chatClient;

    [SerializeField] private GameObject chatCanvas;

    [SerializeField] private InputField chatField;
    [SerializeField] private Text chatDisplay;
    private string _currentMessage;

    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private float scrollPosition;


    private bool _isConnected;

    // Start is called before the first frame update
    void Start()
    {
        _isConnected = true;

        _chatClient = new ChatClient(this);
        _chatClient.Connect(PhotonNetwork.PhotonServerSettings.AppSettings.AppIdChat, PhotonNetwork.AppVersion,
            new AuthenticationValues(PhotonNetwork.LocalPlayer.NickName));
        Debug.Log("Connecting to Chat");
    }

    // Update is called once per frame
    void Update()
    {
        if (_isConnected)
        {
            _chatClient.Service();
        }

        if (Input.GetKey(KeyCode.Return))
        {
            SubmitChatOnClick();
        }
    }

    public void SubmitChatOnClick()
    {
        if (chatField.text != "")
        {
            _chatClient.PublishMessage("RegionChannel", _currentMessage);
            chatField.text = "";
            _currentMessage = "";
        }
        
        chatField.Select();
        chatField.ActivateInputField();
    }

    public void TypeChatOnValueChange(string valueIn)
    {
        _currentMessage = valueIn;
    }

    public void DebugReturn(DebugLevel level, string message)
    {
        Debug.Log("BLA");
    }

    public void OnDisconnected()
    {
        Debug.Log("BLA");
    }

    public void OnConnected()
    {
        Debug.Log("Connected to Chat");
        _chatClient.Subscribe((new string[] { "RegionChannel" }));
    }

    public void OnChatStateChange(ChatState state)
    {
        Debug.Log("BLA");
    }

    public void OnGetMessages(string channelName, string[] senders, object[] messages)
    {
        string msgs = "";

        for (int i = 0; i < senders.Length; i++)
        {
            msgs = string.Format("{0}: {1}", senders[i], messages[i]);

            chatDisplay.text += "\n " + msgs;

            Debug.Log(msgs);
        }

        scrollRect.verticalNormalizedPosition = scrollPosition;
    }

    public void OnPrivateMessage(string sender, object message, string channelName)
    {
        throw new System.NotImplementedException();
    }

    public void OnSubscribed(string[] channels, bool[] results)
    {
        chatCanvas.SetActive(true);
    }

    public void OnUnsubscribed(string[] channels)
    {
        Debug.Log("BLA");
    }

    public void OnStatusUpdate(string user, int status, bool gotMessage, object message)
    {
        Debug.Log("BLA");
    }

    public void OnUserSubscribed(string channel, string user)
    {
        Debug.Log("BLA");
    }

    public void OnUserUnsubscribed(string channel, string user)
    {
        Debug.Log("BLA");
    }
}