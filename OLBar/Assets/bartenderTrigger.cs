using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    }

    void OnTriggerExit2D(Collider2D other)
    {
        User user = other.GetComponent<User>();
        if (user.isLocalPlayer)
        {
            Debug.Log("Player left");
            other.GetComponent<DrinkUI>().enterArea = false;
        }
    }
}
