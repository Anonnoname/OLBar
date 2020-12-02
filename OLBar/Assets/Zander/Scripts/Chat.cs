using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using System;
using Mirror;

    public class Chat : NetworkBehaviour
    {
        /*
            Chat Agent 
        */
        /***************************************
                        CHAT 
        ***************************************/
        public static event Action<User, string> OnMessage;
        public User localUser;
        // [SerializeField] private Canvas chatUI;

        [Command]
        public void CmdSend(string message)
        {
            if (message.Trim() != "")
                RpcReceive($"{message}");
        }

        [ClientRpc]
        public void RpcReceive(string message)
        {

            localUser = this.GetComponent<User>();
            OnMessage?.Invoke(localUser, message);

        }
        /***************************************
                       END CHAT 
        ***************************************/
    }
