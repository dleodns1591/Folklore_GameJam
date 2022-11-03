using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class VideoManager : MonoBehaviour
{
    public VideoPlayer oneBackGround;
    public VideoPlayer loopBackGround;

    void Start()
    {
        VideoStart();
    }

    void Update()
    {
        
    }

    void VideoStart()
    {
        oneBackGround.loopPointReached += CheckOver;
    }

    void CheckOver(UnityEngine.Video.VideoPlayer videoPlayer)
    {
        oneBackGround.gameObject.SetActive(false);
        loopBackGround.gameObject.SetActive(true);
        loopBackGround.Play();
    }
}
