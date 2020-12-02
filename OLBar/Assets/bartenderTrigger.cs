using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bartenderTrigger : MonoBehaviour
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

        Debug.Log("Player entered");
        other.GetComponent<drinkUI>().enterArea = true;
       
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Player left");
        other.GetComponent<drinkUI>().enterArea = false;
    }
}
