using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Leap.Unity;
using Nissensai2022.Runtime;
using UnityEngine;
using UnityEngine.Video;

public class VideoChange : MonoBehaviour
{
    // E,D,C,B,A
    [SerializeField] private VideoClip[] _videoClips;
    private VideoPlayer[] _videoPlayers;
    private ResultRank _resultRank;
    
    public void ChangeVideo(ResultRank rank)
    {
        _resultRank = rank;
        _videoPlayers.ForEach(vp =>
        {
            vp.clip = _videoClips[(int)rank];
            vp.Play();
        });
    }
    
    void Start()
    {
        _videoPlayers = GetComponents<VideoPlayer>();
        _videoPlayers.ForEach(vp =>
        {
            vp.loopPointReached += (vp) =>
            {
                Nissensai2022.Runtime.Nissensai.SendResult(_resultRank);
            };
        });
    }
}
