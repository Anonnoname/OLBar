using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drinkUI : MonoBehaviour
{
    public GameObject bartender;
    public GameObject chatbox;
    public GameObject menu;
    bool activate;
    // Start is called before the first frame update
    void Start()
    {
        bartender.SetActive(false);
        activate = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (activate) {

            bartender.SetActive(true);
        }
    }
}
