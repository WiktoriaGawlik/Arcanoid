using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour {
    public int lives;
    public Text livesText;
    public int score;
    public Text scoreText;
    public bool gameOver;
    public GameObject gameoverPanel;
    public int numberOfBlock;
	
	void Start () {
        livesText.text = "Lives: " + lives;
        //  scoreText.text = "Score: " + score;
        numberOfBlock = GameObject.FindGameObjectsWithTag("Block").Length;
	}
	
	// Update is called once per frame
	void Update () {}
    public void UpdateLives(int changeInLives)
    { lives += changeInLives;
      if (lives <= 0)
        {
            lives = 0;
            GameOver ();
        }
        livesText.text = "Lives; " + lives;
    }
 
    void GameOver()
    {
        gameOver = true;
        gameoverPanel.SetActive(true);
    }
    public void PlayAgain()
    {
        SceneManager.LoadScene("Menu");
    }
    public void Quit()
    {
        Application.Quit();
        Debug.Log("Game Quit");                                                                                                                                                                                                                                                                                                             
    }
}
