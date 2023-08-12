using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class WordCheck : MonoBehaviour
{
    public GridManager gridManager;
    public Dict dict;
    public ScoreManager scoreManager;
    public SoundManager soundManager;
    float bonus;
    int points;

    List<GameObject> roastie = new List<GameObject>();


    public void CheckStrings(GameObject[,] grid)
    {
        // Check rows
        for (int j = 0; j < grid.GetLength(0); j++)
        {
            GameObject[] row = new GameObject[grid.GetLength(1)];

            for (int i = 0; i < grid.GetLength(1); i++)
            {
                row[i] = grid[j, i];
            }

            CreateStrings(row);
        }

        // Check columns
        for (int i = 0; i < grid.GetLength(1); i++)
        {
            GameObject[] column = new GameObject[grid.GetLength(0)];

            for (int j = 0; j < grid.GetLength(0); j++)
            {
                column[j] = grid[j, i];
            }

            CreateStrings(column);
        }
    }

    void CreateStrings(GameObject[] row)
    {
        char[] create = new char[row.Length];

        for (int i = 0; i < row.Length; i++)
        {
            create[i] = row[i].GetComponent<Hacky>().Letter();
        }

        string word = new string(create).ToLower();
        char[] createRev = (char[])create.Clone();  // Create a copy of the array
        Array.Reverse(createRev);  // Reverse the copied array
        string backWord = new string(createRev).ToLower();
        CompareStrings(word, row);
        CompareStrings(backWord, row.Reverse().ToArray());
    }

    void CompareStrings(string word, GameObject[] row)
    {
        string[] wordList = dict.words;
        List<string> foundWord = new List<string>();
        List<GameObject[]> foundRow = new List<GameObject[]>();
        int words = 0;

        if (wordList.Contains(word))
        {
            foundWord.Add(word);
            foundRow.Add(row);
            bonus = 1.5f;
            words += 1;
        }
        else if (word.Length >= 4 && wordList.Contains(word.Substring(0, 4)))
        {
            GameObject[] subRow = row.Take(4).ToArray();
            string subWord = word.Substring(0,4);

            foundWord.Add(subWord);
            foundRow.Add(subRow);
            bonus = 1f;
            words += 1;
        }
        else if (word.Length >= 3 && wordList.Contains(word.Substring(0, 3)))
        {
            GameObject[] subRow = row.Take(4).ToArray();
            string subWord = word.Substring(0,4);

            foundWord.Add(subWord);
            foundRow.Add(subRow);
            bonus = 0.75f;
            words += 1;
        }
        else
        {
            return;
        }

        for(int i=0; i<foundWord.Count; i++)
        {
            FoundWord(foundWord[i], foundRow[i]);
            bonus *= 1.5f;
        }

        scoreManager.bonus = bonus;
        words = 0;
    }

    void FoundWord(string word, GameObject[] row)
    {

        foreach (GameObject block in row)
        {
            scoreManager.AddPoints(block);
            BugFix(block);
            
        }

        soundManager.Found();


    }

    void BugFix(GameObject block)
    {
        if (roastie.Contains(block))
        {
            return;
        }

        roastie.Add(block);
        RemoveBlocks(block);
    }

    void RemoveBlocks(GameObject block)
    {

        GridManager workaround = gridManager;
        block.GetComponent<Hacky>().Morte(workaround);
        
    }


}
