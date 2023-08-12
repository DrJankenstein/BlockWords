using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public static GameManager instance  { get; private set; }
    public int score;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }

        else
        {
            Destroy(this);
        }
    }


    public void StartGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameOver(int score)
    {
        score = score;
        SceneManager.LoadScene("GameOver");

    }


}
