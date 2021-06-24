using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    bool gameEnded = false;
    private int coins = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    //public so we can call addcoins from elsewhere
    public void AddCoins(int numberOfCoins)
    {
        coins += numberOfCoins;
        Debug.Log("Coin picked up! You are holding " + coins + " coins.");
    }

    //make public so it can be seen by other scripts in the program
    public void EndGame()
	{
        if (gameEnded == false)
		{
            Debug.Log("Player died!");
            gameEnded = true;
            //Restart();
            GameOver();
		}
	}

    void Restart()
	{
        //start the game over
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

    void GameOver()
    {
        //load the game over scene
        SceneManager.LoadScene("GameOver");
    }
}
