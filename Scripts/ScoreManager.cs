using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public float bonus;
    int blockScore = 0;

    void Update()
    {
        // Move the score update to the beginning of the Update method
        UpdateScoreText();
    }

   public void AddPoints(GameObject block)
    {
        blockScore += block.GetComponent<Hacky>().Points();
        score += Mathf.FloorToInt(blockScore * bonus);
        Debug.Log(score);
        
        // Call the UpdateScoreText method after updating the score
        UpdateScoreText();
    }

    

    void UpdateScoreText()
    {
        // Update the score text with the current score value
        scoreText.text = score.ToString();
    
    }
}

