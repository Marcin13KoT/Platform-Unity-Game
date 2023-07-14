using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TMP_Text scoreText;
    public float score;
    public TextMeshProUGUI finalscoreText;
    //public int finalscore;
    public PlayfabManager playfabManager;
    bool isDone = false;



    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            score += 1 * Time.deltaTime * 100;
            scoreText.text = ((int)score).ToString();      
        }

        if(GameObject.FindGameObjectWithTag("Respawn") != null) 
        {
            scoreText.faceColor = new Color32(0, 0, 0, 0);
            
            if (!isDone)
            {
                playfabManager.SendLeaderboard((int)score);
                isDone = true;
            }
        }
        
        else if(GameObject.FindGameObjectWithTag("Respawn") == null) 
        {
            scoreText.faceColor = new Color32(255, 255, 255, 180);
            finalscoreText.text = ((int)score).ToString();
        }
    }
}