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


        public override void OnStartLocalPlayer()
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0, 0, -10); // set main camera position
        }

    }

}
