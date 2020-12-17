/**
*   @file OLBarNetworkManager.cs
*   @brief OLBar Network Manager. Used to create new user when players join the game.
*   
*   This file contains functions to handle create server, create player events.
*
*   @author Zander Mao
*   @bug No known bugs.
*/

using UnityEngine;
using Mirror;

[AddComponentMenu("")]
/**
* @brief Class for NetworkManager
*/
public class OLBarNetworkManager : NetworkManager
{
    /**
    * @brief Get and Set username
    */
    public string UserName { get; set; }

    /**
    * @brief Set host address
    * @param[in] hostname - host address of the server
    */
    public void SetHostname(string hostname)
    {
        networkAddress = hostname;
    }

    /**
    * @brief Create message for the server to create user
    */
    public struct CreateUserMessage : NetworkMessage
    {
        public string name;
    }

    /**
    * @brief Evoked when server is started
    *
    * When Server is started, register handler and wait for user to connect
    */
    public override void OnStartServer()
    {
        base.OnStartServer();
        NetworkServer.RegisterHandler<CreateUserMessage>(OnCreateUser);
    }

    /**
    * @brief Evoked when client tries to connect to the network manager.
    * 
    * Send message to the server, request the server to create a new user 
    * based on name provided in the create user message.
    * 
    * @param conn - Network connection object. 
    */
    public override void OnClientConnect(NetworkConnection conn)
    {
        base.OnClientConnect(conn);

        // tell the server to create a player with this name
        conn.Send(new CreateUserMessage { name = UserName });
    }

    /**
    * @brief Evoked when receiving connection message from user
    * 
    * Create user according to the create user message. New user will be added
    * to the scene, a new player prefab will be generated.
    * 
    * @param[in] connection - network connection object
    * @param[in] createUserMessage - message to create user
    */
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
