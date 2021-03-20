using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard : MonoBehaviour
{
    //this is a class designed for environmental hazards. if the player touches any object with this script, they will die.

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
        //check to see if this coin has been picked up by the player, and if so destroy it
        if (other.name == "Player")
        {
            Debug.Log("Player died!");
        }
    }
}
