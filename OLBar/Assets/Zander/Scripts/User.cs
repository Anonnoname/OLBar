using System;
using Mirror;
using UnityEngine;

namespace OLBar
{
    public class User : NetworkBehaviour
    {
        [SyncVar]
        public string userName;

        public static event Action<User, string> OnMessage;

        [Command]
        public void CmdSend(string msg)
        {
            if (msg.Trim() != "")
                RpcReceive(msg.Trim());
        }

        [ClientRpc]
        public void RpcReceive(string msg)
        {
            OnMessage?.Invoke(this, msg);
        }

        void Update()
        {
            if (!isLocalPlayer) {return;}

            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 4f;
            float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * 4f;
            transform.Translate(moveX, 0, moveZ);
        }
    }
}
