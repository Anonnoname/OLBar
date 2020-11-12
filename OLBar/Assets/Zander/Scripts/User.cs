using System;
using Mirror;
using UnityEngine;

namespace OLBar
{
    public class User: NetworkBehaviour
    {
        [SyncVar]
        public string userName;

        public static event Action<User, string> OnMessage;

        public OLBarWindow olbarWindow;

        [Command]
        public void CmdSend(string message)
        {
            if (message.Trim() != "")
                RpcReceive(message.Trim());
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
            float moveY = Input.GetAxis("Vertical") * Time.deltaTime * 4f;
            transform.Translate(moveX, moveY, 0);
        }
    }
}
