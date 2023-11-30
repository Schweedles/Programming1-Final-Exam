using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{   
    private void OnTriggerEnter(Collider other)
    {   //If the object collides with an object tagged as "player" 
        if(other.transform.tag == "Player")
        {   
            //The "coin" object will be destroyed
            Destroy(gameObject); 
        }
    }
}
