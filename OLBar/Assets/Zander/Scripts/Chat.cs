/**
*   @file Chat.cs
*   @brief OL Bar Chat. this file should be attached to chat window object.
*   
*   This file contains user behaviours related to the user's movement, including
*   the rendering of the chat message, handling send message action.
*
*   @author Zander Mao
*   @bug No known bugs.
*/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Mirror;

/**
*   @brief Chat class. 
*/
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

    /**
    *   @brief send commend to the server, trigger send message.
    *
    *   Send message to all the other players. Server will distribute the command.
    *
    *   @param[string] - message content
    *   @bug No known bug.
    */
    [Command]
    public void CmdSend(string message)
    {
        if (message.Trim() != "")
            RpcReceive($"{message}");
    }

    /**
    *   @brief receive message from server, display message in Chat window.
    *   
    *   Receive message from the server
    *   
    *   @param[string] - message content
    *   @bug No known bug.
    */
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
