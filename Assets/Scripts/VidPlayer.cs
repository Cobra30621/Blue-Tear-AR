using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VidPlayer : MonoBehaviour
{
    public string videoFileName;
    public VideoPlayer videoPlayer;
    public MeshRenderer defaultRenderer; // 預設的 Mesh Renderer

    private void Awake()
    {
        var videoPath = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        Debug.Log(videoPath);

        videoPlayer.url = videoPath;
        videoPlayer.prepareCompleted += OnVideoPrepared; // 註冊影片準備完成的事件
        videoPlayer.Prepare();   
    }

    private void OnVideoPrepared(VideoPlayer source)
    {
        defaultRenderer.enabled = false;
        videoPlayer.Play();
    }

    public void Play()
    {
        defaultRenderer.enabled = true;
        
        videoPlayer.Prepare();
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