using UnityEngine;
using UnityEngine.UI;
using Mirror;
using System.Collections;

namespace OLBar
{
    public class OLBarWindow : NetworkBehaviour 
    {
        static readonly ILogger logger = LogFactory.GetLogger(typeof(OLBarWindow));

        public InputField chatMessage;
        public Text chatHistory;
        public User user;
        public Scrollbar scrollbar;
        
        public void Awake()
        {
            User.OnMessage += OnUserMessage;
        }

        void OnUserMessage(User user, string message)
        {
            string prettyMessage = user.isLocalPlayer ?
                $"<color=red>{user.userName}: </color> {message}" :
                $"<color=blue>{user.userName}: </color> {message}";
            AppendMessage(prettyMessage);

            logger.Log(message);
        }

        public void OnSend()
        {
            if (chatMessage.text.Trim() == "")
                return;
            User user = NetworkClient.connection.identity.GetComponent<User>();
            user.CmdSend(chatMessage.text.Trim());
            chatMessage.text = "";
        }

        internal void AppendMessage(string message)
        {
            StartCoroutine(AppendAndScroll(message));
        }

        IEnumerator AppendAndScroll(string message)
        {
            chatHistory.text += message;

            // it takes 2 frames for the UI to update ?!?!
            yield return null;
            yield return null;

            scrollbar.value = 0;
        }
    }
}
