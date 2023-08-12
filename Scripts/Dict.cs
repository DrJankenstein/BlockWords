using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class Dict : MonoBehaviour
{
    public string[] words;

    void Awake()
    {
        string filePath = "Assets/dict.txt";
        string[] allWords = File.ReadAllLines(filePath);
        words = allWords.Where(word => word.Length <= 5).Select(word => word.ToLower()).ToArray();
    }
}
