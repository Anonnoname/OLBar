using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class BartenderTrigger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        User user = other.GetComponent<User>();
        if (user.isLocalPlayer)
        {
            Debug.Log("Player entered");
            other.GetComponent<DrinkUI>().enterArea = true;
        }

        
        if (other.GetComponent<User>().isLocalPlayer)
        {
            Debug.Log("Player entered");
            other.GetComponent<drinkUI>().enterArea = true;
        }
        
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.GetComponent<User>().isLocalPlayer)
        {
           Debug.Log("Player left");
        other.GetComponent<drinkUI>().enterArea = false; 
        }
        
    }
}
