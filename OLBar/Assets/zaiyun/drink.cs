/**
*   @file Drink.cs
*   @brief Drink script. Attached to user prefab
*   
*   This file contains functions to handle user's drink actions in the bar 
*
*   @author Zander Mao
*   @author Zaiyun Lin
*   @bug No known bugs.
*   @todo Add different effects for different drinks.
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

/**
*   @brief Handle drink events.
*/
public class Drink : NetworkBehaviour
{
    User user;
    // Start is called before the first frame update
    void Start()
    {
        if (!isLocalPlayer)
            return;
        user = GetComponent<User>();
    }

    /**
    *   @brief Invoked when drinking in the bar.
    *   @param[in] wine - the wine the user drinks.
    *   @todo Design different effects for different drinks.
    */
    public void drink(string wine)
    {
        user.sanity -= 10;
    }
}