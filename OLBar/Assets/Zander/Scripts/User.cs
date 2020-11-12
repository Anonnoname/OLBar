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

        // public Chat chat; // chat agent
        
        /***************************************
                        CHAT 
        ***************************************/
        public static event Action<User, string> OnMessage;
        // public User localUser;
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

            // localUser = (User)gameObject.GetComponent<User>();
            OnMessage?.Invoke(this, message);

        }
        /***************************************
                       END CHAT 
        ***************************************/

    }
}
