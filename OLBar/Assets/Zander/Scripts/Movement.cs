using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace OLBar
{
    public class Movement : NetworkBehaviour
    {
        int state;
        float count;
        float count2;
        float moveX;
        float moveY;
        private void Start()
        {
           // state = 1;
        }

        void Update()
        {

            if (!isLocalPlayer)
                return;
           
         
            User user = GetComponent<User>();
            if (user.sanity > 60) {
                state = 1;
            }else {
                state = 0;
            }
            switch (state) {
                case 0:
                    moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f;
                    moveY = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f;
                    transform.Translate(moveX, moveY, 0);
                    break;
                case 1:
                    count += Random.Range(0, 0.02f);
                    moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f + 0.01f * Mathf.Sin(count);
                    count2 += Random.Range(0, 0.03f);
                    moveY = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f + 0.01f * Mathf.Sin(count2);
                  
                    if (count > 10){
                        count = 0;
                        count2 = 0;}
                    transform.Translate(-moveX,-moveY, 0);
                    break;


            }
        }

    }
}
