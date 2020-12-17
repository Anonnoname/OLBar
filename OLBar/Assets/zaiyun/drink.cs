using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

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

    public void drink(string wine)
    {
        user.sanity -= 10;
    }
}