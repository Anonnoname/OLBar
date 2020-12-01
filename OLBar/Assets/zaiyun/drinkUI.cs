using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class drinkUI : NetworkBehaviour
{
    public GameObject bartender;
    public GameObject chatbox;
    public GameObject menu;
    public bool activate;
    // Start is called before the first frame update
    void Start()
    {

        bartender.SetActive(false);
        chatbox.SetActive(false);
        menu.SetActive(false);

        activate = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (activate) {

            bartender.SetActive(true);
            chatbox.SetActive(true);
            menu.SetActive(true);

        }
    }
}
