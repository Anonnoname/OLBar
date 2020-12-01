using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace OLBar
{
    public class drink : NetworkBehaviour
    {
        User user;
        // Start is called before the first frame update
        void Start()
        {
            if (!isLocalPlayer)
                return;
             user = GetComponent<User>();
        }

        // Update is called once per frame
        void Update()
        {

        }

     public void Drink(string name)
        {
            user.sanity -= 10;


        }
    }
}