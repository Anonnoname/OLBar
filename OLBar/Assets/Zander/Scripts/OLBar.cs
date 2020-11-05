using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

namespace OLBar
{
    public class OLBar : MonoBehaviour
    {
        static readonly ILogger logger = LogFactory.GetLogger(typeof(OLBar));

        public InputField chatMessage;
        public Text chatHistory;
        public void Awake()
        {
        }

        void OnUserMessage(User user, string msg)
        {
            
        }
    }

}
