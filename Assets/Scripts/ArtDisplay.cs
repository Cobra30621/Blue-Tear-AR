using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ArtDisplay : MonoBehaviour
{
    public VidPlayer light, blueTear, SunVideoPlayer;

    public VidPlayer[] vidPlayers;

    
    #region Sun

    public void ShowSun()
    {
        StartCoroutine(SunCoroutine());
    }
    
    private IEnumerator SunCoroutine()
    {
        StopAllVidPlayers();
        
        SunVideoPlayer.gameObject.SetActive(true);
        SunVideoPlayer.Play();
        
        yield return new WaitUntil(()=>SunVideoPlayer.videoPlayer.frame == 200);
        
        SunVideoPlayer.Stop();
        SunVideoPlayer.gameObject.SetActive(false);
    }
    

    #endregion

    #region Light

    public void ShowLight()
    {
        
        StartCoroutine(LightCoroutine());
    }

    private IEnumerator LightCoroutine()
    {   
        StopAllVidPlayers();
        
        light.gameObject.SetActive(true);
        light.Play();
        
        yield return new WaitForSeconds(5f);
        light.Pause();
        light.gameObject.SetActive(false);
    }
    

    #endregion

    #region Blue Tear

    public void ShowBlueTear()
    {
        StartCoroutine(BlueTearCoroutine());
    }
    
    private IEnumerator BlueTearCoroutine()
    {
        StopAllVidPlayers();

        blueTear.gameObject.SetActive(true);
        blueTear.Play();
        
        yield return new WaitForSeconds(5f);
        blueTear.gameObject.SetActive(false);
    }

    #endregion

    private void StopAllVidPlayers()
    {
        foreach (var vidPlayer in vidPlayers)
        {
            vidPlayer.gameObject.SetActive(false);
        }
    }
}
