using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public VideoClip fieldClip;
    public GameObject interactionPanel;
    public RawImage rawImage;
    public RenderTexture renderTexture;

    private bool canPlay;


    private void Start()
    {
        canPlay = true;
    }

    public void OnTapButtonPressed()
    {
        Caching.ClearCache();
        StartCoroutine(PlayVideo());
    }

    IEnumerator PlayVideo()
    {
        //renderTexture.Release();
        //videoPlayer.clip = fieldClip;
        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
        {
            yield return null;
        }

        interactionPanel.SetActive(false);
        //videoPlayer.Stop();
        videoPlayer.Play();

        yield return new WaitForSeconds((float)fieldClip.length + 0.5f);
        //canPlay = true;
        interactionPanel.SetActive(true);
    }
}
