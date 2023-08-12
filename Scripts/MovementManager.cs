using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MovementManager : MonoBehaviour
{
    public GridManager gridManager;
    public WordCheck wordCheck;
    public Button butx1;
    public Button butx2;
    public Button butx3;
    public Button butx4;
    public Button butx5;
    public Button buty1;
    public Button buty2;
    public Button buty3;
    public Button buty4;
    public Button buty5;
    
    GameObject[,] grid;

    GameObject fuckIt;

    void Start()
    {
        grid = gridManager.grid;
        butx1.onClick.AddListener(() => MoveRow(0, null));
        butx2.onClick.AddListener(() => MoveRow(1, null));
        butx3.onClick.AddListener(() => MoveRow(2, null));
        butx4.onClick.AddListener(() => MoveRow(3, null));
        butx5.onClick.AddListener(() => MoveRow(4, null));
        buty1.onClick.AddListener(() => MoveRow(null, 4));
        buty2.onClick.AddListener(() => MoveRow(null, 3));
        buty3.onClick.AddListener(() => MoveRow(null, 2));
        buty4.onClick.AddListener(() => MoveRow(null, 1));
        buty5.onClick.AddListener(() => MoveRow(null, 0));



    }


    void MoveRow(int? row, int? column)
    {
        grid = gridManager.grid;
        if (row.HasValue)
        {
            // Extract a subarray of items from a specific row
            int rowIndex = row.Value; // Row index to extract
            GameObject[] rowItems = new GameObject[grid.GetLength(1)]; // Subarray to store row items

            for (int j = 0; j < grid.GetLength(1); j++)
            {
                rowItems[j] = grid[rowIndex, j];
            }


            MoveIt(rowItems);
        }

        if (column.HasValue)
        {
            // Extract a subarray of items from a specific column
            int columnIndex = column.Value; // Column index to extract
            GameObject[] columnItems = new GameObject[grid.GetLength(0)]; // Subarray to store column items

            for (int i = 0; i < grid.GetLength(0); i++)
            {
                columnItems[i] = grid[i, columnIndex];
            }

            MoveIt(columnItems);

        }
    }

    void MoveIt(GameObject[] row)
    {
        //i hate unity. this is the hackiest work around ever, worse than the hacky way to attah a scriptable object
        GameObject temp = GameObject.Instantiate(row[0]);

        for (int i = 0; i < row.Length - 1; i++)
        {
            row[i].GetComponent<Hacky>().AttachObject(row[i + 1].GetComponent<Hacky>().blockObject);
            row[i].GetComponent<Renderer>().material = row[i + 1].GetComponent<Renderer>().material;
        }

        row[row.Length - 1].GetComponent<Hacky>().AttachObject(temp.GetComponent<Hacky>().blockObject);
        row[row.Length - 1].GetComponent<Renderer>().material = temp.GetComponent<Renderer>().material;

        wordCheck.CheckStrings(grid);
        Destroy(temp);
    }


}