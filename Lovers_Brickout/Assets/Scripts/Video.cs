using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class Video : MonoBehaviour
{
    VideoPlayer video;

    [SerializeField] private int level;
 
    void Awake()
    {
        video = GetComponent<VideoPlayer>();
        video.Play();
        video.loopPointReached += CheckOver;
    }
 
 
     void CheckOver(UnityEngine.Video.VideoPlayer vp){
        FindObjectOfType<GameManager>().LoadGameLevel(level);
    }
}
