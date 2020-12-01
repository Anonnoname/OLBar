using UnityEngine;
using System.Collections;
using Mirror;

public class ClickManager : MonoBehaviour
{
    public drinkUI dui;
    void Update () {
        if (Input.GetMouseButtonDown(0)) {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);
            
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null) {
                Debug.Log(hit.collider.gameObject.name);
                //hit.collider.attachedRigidbody.AddForce(Vector2.up);
                if(hit.collider.gameObject.name == "bartender") {
                     dui = GetComponent<drinkUI>();
                    dui.activate = true;
               }
            }

        }
    }

}