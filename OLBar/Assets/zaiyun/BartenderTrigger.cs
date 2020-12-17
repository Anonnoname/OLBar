/**
*   @file BartenderTrigger.cs
*   @brief Trigger interaction when user gets close. Attached to user prefab.
*   
*   This class handles interaction between user and the environemt. When user
*   gets close enough, the user would be able to trigger interactions with bar.   
*
*   @author Zander Mao
*   @author Zaiyun Lin
*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BartenderTrigger : NetworkBehaviour
{
    /**
    *   @brief Called when collider enters the trigger area
    *      
    *   @param[Collider2D] - the other object that enters the trigger
    *   @bug No known bug.
    */
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<User>().isLocalPlayer) 
        // only trigger if is local player
        {
            other.GetComponent<DrinkUI>().enterArea = true;
        }
    }

    /**
    *   @brief Called when collider exits the trigger area
    *      
    *   @param[Collider2D] - the other object that exits the trigger
    *   @bug No known bug.
    */
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<User>().isLocalPlayer)
        // only trigger if is local player
        {
            other.GetComponent<DrinkUI>().enterArea = false; 
        }
        
    }
}
