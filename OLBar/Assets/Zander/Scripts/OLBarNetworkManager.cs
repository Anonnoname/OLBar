using UnityEngine;
using Mirror;

namespace OLBar
{
    [AddComponentMenu("")]
    public class OLBarNetworkManager : NetworkManager
    {
        public string UserName { get; set; }

        public void SetHostname(string hostname)
        {
            networkAddress = hostname;
        }

        public struct CreateUserMessage : NetworkMessage
        {
            public string name;
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<CreateUserMessage>(OnCreateUser);
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);

            // tell the server to create a player with this name
            conn.Send(new CreateUserMessage{ name = UserName });
        }

        void OnCreateUser(NetworkConnection connection, CreateUserMessage createUserMessage)
        {
            // create a gameobject using the name supplied by client
            GameObject usergo = Instantiate(playerPrefab);
            User user = usergo.GetComponent<User>();

            user.userName = createUserMessage.name;

            // set it as the player
            NetworkServer.AddPlayerForConnection(connection, usergo);

        }
    }
}
