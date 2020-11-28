using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace OLBar
{

	public class Jukebox: NetworkBehaviour
	{
		// Music Player with shared playlist
		bool isPlaying;

		bool mute = false;

		[SyncVar]
		int currentSong = 0;

	    void Start()
	    {
			isPlaying = false;
	    }

		void ChooseSong (int index) {
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

		void Mute () {
			AudioSource song = GetComponent<AudioSource>();
			song.mute = !song.mute;
		}
	    // Update is called once per frame
	}
}
