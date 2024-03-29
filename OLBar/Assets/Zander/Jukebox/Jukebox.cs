﻿/**
*   @file Jukebox.cs
*   @brief Create shared jukebox. Not finished.    
*
* 	This file is reserved for a shared jukebox
*
*   @author Zander Mao
*   @todo implement synchronized jukebox
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;


public class Jukebox : NetworkBehaviour
{
    // Music Player with shared playlist
    bool isPlaying;

    bool mute = false;

    public GameObject canvas;

    [SyncVar]
    public int currentSong = 0;

    void Start()
    {
        isPlaying = false;
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Player entered");
        canvas.SetActive(true);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player left");
        canvas.SetActive(false);
    }

    void ChooseSong(int index)
    {
        User user = GetComponent<User>();
        user.currency -= 10;
        AudioSource song = GetComponent<AudioSource>();
        CmdPlaySong(index);
        song.Play();
    }

    [Command]
    void CmdPlaySong(int index)
    {
        RpcPlay(index);
    }

    [ClientRpc]
    void RpcPlay(int index)
    {
        GameObject Playlist = GameObject.Find("Playlist").GetComponent<GameObject>();
        AudioSource song = GameObject.Find($"Song{index}").GetComponent<AudioSource>();
        song.Play(0);
    }

    void Mute()
    {
        AudioSource song = GetComponent<AudioSource>();
        song.mute = !song.mute;
    }
    // Update is called once per frame
}