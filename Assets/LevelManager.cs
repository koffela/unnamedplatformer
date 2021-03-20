using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public int coins = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void AddCoins(int numberOfCoins)
    {
        coins += numberOfCoins;
        Debug.Log("Coin picked up! You are holding " + coins + " coins.");
    }

    //make public so it can be seen by other scripts in the program
    public void EndGame()
	{
        Debug.Log("Player died!");
	}
}
