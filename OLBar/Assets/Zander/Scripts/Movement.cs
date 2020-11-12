using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace OLBar
{
    public class Movement : NetworkBehaviour
    {
        void Update()
        {
            if (!isLocalPlayer)
                return;
            float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * 4.0f;
            float moveY = Input.GetAxis("Vertical") * Time.deltaTime * 4.0f;
            transform.Translate(moveX, moveY, 0);
        }
    }
}
