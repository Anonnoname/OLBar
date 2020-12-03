using System;
using Mirror;
using UnityEngine;


    public class User: NetworkBehaviour
    {
        [SyncVar]
        public string userName;

        [SyncVar]
        public int sanity; // sanity system

        [SyncVar]
        public int currency; // currency system

        [SyncVar]
        public float sleepiness; // sleepiness

        [SyncVar]
        public float hunger; // sleepiness

        public GameObject chatBox; // chatbox

        // VISUAL EFFECTS


        // chatwindow


        public override void OnStartLocalPlayer()
        {
            Camera.main.transform.SetParent(transform);
            Camera.main.transform.localPosition = new Vector3(0, 0, -10); // set main camera position


            // initialize user
            this.currency = 1000;
            this.sanity = 100;
            this.hunger = 0;
            this.sleepiness = 0;

            // setup localUser
            ChatWindow window = GameObject.Find("ChatWindow").GetComponent<ChatWindow>();
            window.localUser = this;

            // setup visual effects


            InvokeRepeating("Tired", 5.0f, 0.0001f);
        }


        private void Tired()
        {
            if (hunger < 100)
            {
                hunger += 0.0001f;
            }
            if (sleepiness < 1)
            {
                sleepiness += 0.000001f;
            }
        }

        void Update()
        {

        }


    }


