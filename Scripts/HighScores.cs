using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class HighScores : MonoBehaviour
{
    
    string filepath;
    public string[] initials = new string[5];
    public int[] scores = new int[5];

    void Awake()
    {
        filepath = "Assets/highscores.txt";
    }

    // public void LoadHighScores()
    // {
    //     string[] fulltext = File.ReadAllLines(filepath);

    //     foreach (string line in fulltext)
    //     {
            
    //     }
  //  }

}
