/**
*   @file ChatWindow.cs
*   @brief OL Bar Chat Window. this file should be binded to chat window object
*   
*   This file contains user behaviours related to the user's movement, including
*   the rendering of the chat message, handling send message action.
*
*   @author Zander Mao
*   @bug No known bugs.
*/

using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;


<<<<<<< HEAD
=======
/**
*   @brief Class for ChatWindow
*/
>>>>>>> zander_n
public class ChatWindow : NetworkBehaviour
{
    public InputField chatMessage;
    public Chat chat;
    public User localUser;

    /**
    *   @brief Invoked when chatwindow is awake
    */
    public void Awake()
    {
        Chat.OnMessage += OnUserMessage;
    }

    /**
    *   @brief function invoked when the user receives the message.
    *   @param[in] user - the user who sent the message.
    *   @param[in] message - the message received.
    */
    public void OnUserMessage(User user, string message)
    {
        StartCoroutine(ShowMessage(user, message));
    }

    /**
    *   @brief Coroutine for displaying message. 
    *
    *   The user can always see the message sent. However, if the distance 
    *   between the user and another is too far, the user can't see the other 
    *   user's message. By default, the message is displayed for 5 seconds.
    *   
    *   @param[in] user - the user who sent the message.
    *   @param[in] message - the content of the message.
    *   @bug No known bug.
    */
    IEnumerator ShowMessage(User user, string message)
    {
        Text text = user.chatBox.GetComponent<Text>();
        // text.text = message;
        if (user.isLocalPlayer)
        {
            text.text = message;
            yield return new WaitForSeconds(5f);
        }
        else
        {
            for (int i = 0; i < 500; ++i)
            {
                float distance = Vector3.Distance(user.transform.position, localUser.transform.position);
                if (distance > 5)
                {
                    text.text = "******";
                }
                else
                {
                    text.text = message;
                }
                yield return new WaitForSeconds(0.01f);
            }

        }
        text.text = "";
    }

    /**
    *   @brief Invoked when press send button
    *
    *   Send message to server. Empty message and white characters will be 
    *   trimmed.
    */
    public void OnSend()
    {
        if (chatMessage.text.Trim() == "")
            return;
        Debug.Log("message pass");

        // get our user
        chat = NetworkClient.connection.identity.GetComponent<Chat>();

        // send a message
        chat.CmdSend(chatMessage.text.Trim());

        chatMessage.text = "";
    }
}
