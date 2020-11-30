using System;
using Mirror;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

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

		public GameObject postProcessing; // post processing filter


        public override void OnStartLocalPlayer()
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0, 0, -10); // set main camera position
			InvokeRepeating("DecreaseHunger", 5.0f, 5.0f);
        }

		private void DecreaseHunger()
		{
			if (this.hunger > 0) {
				this.hunger -= 1;
			}
		}

    }

}
