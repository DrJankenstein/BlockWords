using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text scoreText;

    public void Start()
    {
        int score = GameManager.instance.score;
        scoreText.text = score.ToString();
    }
}
