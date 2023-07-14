using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverPanel;
    public GameObject leaderboardPanel;


    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") == null)
        {
            gameOverPanel.SetActive(true);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }

    public void Quit()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Leaderboard()
    {
        leaderboardPanel.SetActive(true);
    }
}
