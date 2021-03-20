using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //access the levelmanager script
    private LevelManager gameLevelManager;
    public Rigidbody2D rb;
    int coinValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        //coinValue = 100;
        rb = GetComponent<Rigidbody2D>();
        gameLevelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
	{
        //rb.isKinematic = false;
        //check to see if this coin has been picked up by the player, and if so destroy it
        if (other.name == "Player")
		{
            gameLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
            //Debug.Log("Coin picked up!");
        }
	}

    /*
    void OnCollisionEnter2D(Collider2D other)
    {
        //check to see if this coin has been picked up by the player, and if so destroy it
        if (other.name == "Player")
        {
            gameLevelManager.AddCoins(coinValue);
            Destroy(gameObject);
            //Debug.Log("Coin picked up!");
        }
    }
    */

    //TO DO: more than one coin script, so we need to pass the score another way
}
