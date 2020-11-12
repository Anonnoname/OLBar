using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;

namespace OLBar
{
    public class ChatWindow : NetworkBehaviour
    {
        static readonly ILogger logger = LogFactory.GetLogger(typeof(ChatWindow));

        public InputField chatMessage;
        public Text chatHistory;
        public User user;

        public void Awake()
        {
            User.OnMessage += OnUserMessage;
        }

        void OnUserMessage(User user, string message)
        {
            string prettyMessage = user.isLocalPlayer ?
                $"\n<color=red>{user.userName}: </color> {message}" :
                $"\n<color=blue>{user.userName}: </color> {message}";
            AppendMessage(prettyMessage);
            logger.Log(message);
        }

        public void OnSend()
        {
            if (chatMessage.text.Trim() == "")
                return;
            Debug.Log("message pass");

            // get our user
            user = NetworkClient.connection.identity.GetComponent<User>();

            // send a message
            user.CmdSend(chatMessage.text.Trim());

            chatMessage.text = "";
        }

        internal void AppendMessage(string message)
        {
            StartCoroutine(AppendAndScroll(message));
        }

        IEnumerator AppendAndScroll(string message)
        {
            chatHistory.text += $"{message}";

            // it takes 2 frames for the UI to update ?!?!
            yield return null;
            yield return null;

        }
    }
}
