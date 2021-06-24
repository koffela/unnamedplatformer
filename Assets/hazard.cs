using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hazard : MonoBehaviour
{
    //this is a class designed for environmental hazards. if the player touches any object with this script, they will die.
    //private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        //rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //check to see if the player has hit the hazard
        if (other.name == "Player")
        {
            FindObjectOfType<LevelManager>().EndGame();
        }
    }
}
