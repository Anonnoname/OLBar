using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;

namespace OLBar
{
    public class ChatWindow : NetworkBehaviour
    {
        public InputField chatMessage;
        public Text chatHistory;
        public Chat chat;
        public User localUser;

        public void Awake()
        {
            Chat.OnMessage += OnUserMessage;
        }

        void OnUserMessage(User user, string message)
        {
            StartCoroutine(ShowMessage(user, message));
        }

        IEnumerator ShowMessage(User user, string message)
        {
            Text text = user.chatBox.GetComponent<Text>();
            // text.text = message;
            if (user.isLocalPlayer)
            {
                text.text = message;
            }
            else
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

            }

            yield return new WaitForSeconds(5);
            text.text = "";
        }


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
}
