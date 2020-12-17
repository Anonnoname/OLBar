using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;


public class DrinkUI : NetworkBehaviour
{
    public GameObject bartender;
    public GameObject chatbox;
    public GameObject chatboxText;
    public GameObject menu;
    public GameObject interact;
    public GameObject selectionSquare;
    Vector2[] pos;
    public bool activate;
    public bool enterArea;
    public bool isLeft = true;
    public bool isTop = true;
    // Start is called before the first frame update
    void Start()
    {
        enterArea = false;
        bartender.SetActive(false);
        chatbox.SetActive(false);
        menu.SetActive(false);
        interact.SetActive(false);
        chatboxText.SetActive(false);
        activate = false;

    }

    // Update is called once per frame
    void Update()
    {

        if (activate)
        {
            bartender.SetActive(true);
            chatbox.SetActive(true);
            menu.SetActive(true);
            chatboxText.SetActive(true);
            GetComponent<Movement>().state = 2;


            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (!isTop)
                {
                    Vector2 currPos = selectionSquare.transform.localPosition;
                    currPos.y += 2;
                    selectionSquare.transform.localPosition = currPos;
                    isTop = !isTop;

                }
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (isTop)
                {
                    Vector2 currPos = selectionSquare.transform.localPosition;
                    currPos.y -= 2;
                    selectionSquare.transform.localPosition = currPos;
                    isTop = !isTop;

                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (!isLeft)
                {
                    Vector2 currPos = selectionSquare.transform.localPosition;
                    currPos.x -= 4;
                    selectionSquare.transform.localPosition = currPos;
                    isLeft = !isLeft;

                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (isLeft)
                {
                    Vector2 currPos = selectionSquare.transform.localPosition;
                    currPos.x += 4;
                    selectionSquare.transform.localPosition = currPos;
                    isLeft = !isLeft;

                }
            }
            if (Input.GetKeyDown(KeyCode.Return))
            {
                Drink drink = GetComponent<Drink>();
                if (isLeft && isTop)
                {
                    drink.drink("beer");
                }
                else if (!isLeft && isTop)
                {
                    drink.drink("beer");
                }
                else if (isLeft && !isTop)
                {
                    drink.drink("beer");
                }
                else if (!isLeft && !isTop)
                {
                    drink.drink("beer");
                }
            }



        }
        else
        {

            bartender.SetActive(false);
            chatbox.SetActive(false);
            menu.SetActive(false);
            chatboxText.SetActive(false);
            GetComponent<Movement>().state = 0;
        }
        if (enterArea)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                activate = !activate;
            }
            interact.SetActive(true);
        }
        else
        {
            interact.SetActive(false);
        }

    }
}

