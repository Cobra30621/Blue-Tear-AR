using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    public string videoFileName;
    public VideoPlayer videoPlayer;

    
    private void Awake()
    {
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(videoPath);

        videoPlayer.url = videoPath;
        videoPlayer.Prepare();
    }

    public void Play()
    {
        videoPlayer.Play();
    }

    public void Pause()
    {
        videoPlayer.Pause();
    }
    
    public void Stop()
    {
        videoPlayer.Stop();
    }
}
