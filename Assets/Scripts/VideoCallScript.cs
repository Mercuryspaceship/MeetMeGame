using Agora_RTC_Plugin.API_Example.Examples.Basic.JoinChannelVideo;
using UnityEngine;
using UnityEngine.UI;

public class VideoCallScript : MonoBehaviour
{
    [SerializeField] private GameObject videoCanvas;

    [SerializeField] private GameObject videoLoadingInfo;

    [SerializeField] private GameObject videoKeysInfo;

    [SerializeField] private JoinChannelVideo joinChannelVideo;

    [SerializeField] private bool camEnabled = true;

    [SerializeField] private bool micEnabled = true;

    private Texture _tempTexture;

    public void EnableVideoCall()
    {
        videoLoadingInfo.SetActive(true);

        videoCanvas.GetComponent<Canvas>().enabled = false;

        videoCanvas.SetActive(true);
        joinChannelVideo.Start();

        Invoke("EnableVideoCanvas", 3f);

        videoKeysInfo.SetActive(true);
    }

    public void DisableVideoCall()
    {
        videoLoadingInfo.SetActive(false);

        videoKeysInfo.SetActive(false);

        joinChannelVideo.OnDestroy();

        videoCanvas.SetActive(false);
    }

    private void EnableVideoCanvas()
    {
        videoCanvas.GetComponent<Canvas>().enabled = true;
        videoLoadingInfo.SetActive(false);
    }

    public bool VideoCanvasIsActive()
    {
        return videoCanvas.activeSelf;
    }

    public void ToggleCamera()
    {
        camEnabled = !camEnabled;

        joinChannelVideo.EnableCamera(camEnabled);

        if (!camEnabled)
        {
            _tempTexture = GameObject.Find("0").GetComponent<RawImage>().texture;

            DeleteCamTexture();
        }
        else
        {
            LoadCamTexture();
        }
    }

    public void ToogleMic()
    {
        micEnabled = !micEnabled;

        joinChannelVideo.EnableMic(micEnabled);
    }

    private void DeleteCamTexture()
    {
        GameObject.Find("0").GetComponent<RawImage>().texture = null;
    }

    private void LoadCamTexture()
    {
        GameObject.Find("0").GetComponent<RawImage>().texture = _tempTexture;
    }
}