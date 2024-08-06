using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ArtDisplay : MonoBehaviour
{
    public VidPlayer light, blueTear, SunVideoPlayer;

    public VidPlayer[] vidPlayers;

    public MeshRenderer defaultRenderer; // 預設的 Mesh Renderer
    

    public void OnFound()
    {
        defaultRenderer.enabled = true;
    }

    public void OnLeaved()
    {
        StopAllVidPlayers();
        
        light.gameObject.SetActive(false);
        blueTear.gameObject.SetActive(false);
        SunVideoPlayer.gameObject.SetActive(false);
    }
    

    #region Sun
    [ContextMenu("Show Sun")]
    public void ShowSun()
    {
        StartCoroutine(SunCoroutine());
    }
    
    private IEnumerator SunCoroutine()
    {
        StopAllVidPlayers();
        
        SunVideoPlayer.gameObject.SetActive(true);
        SunVideoPlayer.Play();
        
        // yield return new WaitUntil(()=> SunVideoPlayer.videoPlayer.frame == 200);
        yield return new WaitForSeconds(10f);
        
        SunVideoPlayer.Stop();
        defaultRenderer.enabled = true;
        SunVideoPlayer.gameObject.SetActive(false);
    }
    

    #endregion

    #region Light
    [ContextMenu("Show Light")]
    public void ShowLight()
    {
        
        StartCoroutine(LightCoroutine());
    }

    private IEnumerator LightCoroutine()
    {   
        StopAllVidPlayers();
        
        light.gameObject.SetActive(true);
        light.Play();
        
        yield return new WaitForSeconds(10f);
        defaultRenderer.enabled = true;
        light.gameObject.SetActive(false);
        
       
    }
    

    #endregion

    #region Blue Tear
    [ContextMenu("Show Blue Tear")]
    public void ShowBlueTear()
    {
        StartCoroutine(BlueTearCoroutine());
    }
    
    private IEnumerator BlueTearCoroutine()
    {
        StopAllVidPlayers();

        blueTear.gameObject.SetActive(true);
        blueTear.Play();
        
        yield return new WaitForSeconds(10f);
        defaultRenderer.enabled = true;
        blueTear.gameObject.SetActive(false);
    }

    #endregion

    private void StopAllVidPlayers()
    {
        foreach (var vidPlayer in vidPlayers)
        {
            vidPlayer.gameObject.SetActive(false);
        }
        defaultRenderer.enabled = false;
    }
}
