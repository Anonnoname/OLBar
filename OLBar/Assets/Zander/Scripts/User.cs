using System;
using Mirror;
using UnityEngine;

namespace OLBar
{
    public class User: NetworkBehaviour
    {
        [SyncVar]
        public string userName;

        [SyncVar]
        public int sanity; // sanity system

        [SyncVar]
        public int currency; // currency system

		[SyncVar]
		public int sleepiness; // sleepiness

		[SyncVar]
		public int hunger; // sleepiness

		public GameObject chatBox; // chatbox

    }
}
