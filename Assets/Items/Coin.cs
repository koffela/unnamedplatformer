using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //several ways to call the other script

    //private LevelManager gameLevelManager;
    //gameLevelManager = FindObjectOfType<LevelManager>();
    //gameLevelManager.AddCoins(coinValue);

    //FindObjectOfType<LevelManager>().AddCoins(coinValue);


    //access the levelmanager script

    private Rigidbody2D rb;
    private int coinValue = 1;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
            FindObjectOfType<LevelManager>().AddCoins(coinValue);
            Destroy(gameObject);
            //Debug.Log("Coin picked up!");
        }
	}
}
