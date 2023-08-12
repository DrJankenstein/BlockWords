using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    int rows = 5;
    int columns = 5;
    public GameObject[,] grid;
    public List<BlockObjects> letters = new List<BlockObjects>();
    public GameObject dictionary;
    private bool[,] isEmpty;

    void Start()
    {
        InitializeGrid();
        FillGrid();
        TestMethod();
    }

    void InitializeGrid()
    {
        grid = new GameObject[rows, columns];
        isEmpty = new bool[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                isEmpty[i, j] = true;
            }
        }
    }

    public void FillGrid()
    {
        // Loop through the grid and fill only the empty cells
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                if (!IsEmpty(i, j))
                {
                    // If the cell is not empty, skip filling it
                    continue;
                }

                grid[i, j] = CreateALetter(i, j);
                SetCellNotEmpty(i, j);
            }
        }
    }


    bool IsEmpty(int row, int col)
    {
        return isEmpty[row, col];
    }

    public void SetCellEmpty(int row, int col)
    {
        isEmpty[row, col] = true;
    }

    void SetCellNotEmpty(int row, int col)
    {
        isEmpty[row, col] = false;
    }


    GameObject CreateALetter(int row, int column)
    {
        // Pick a random scriptable object from the list
        int rand = Random.Range(0, letters.Count);
        BlockObjects letter = letters[rand];

        // Get the texture from the BlockObjects scriptable object
        Texture2D cubeTexture = letter.letterTex;

        // Create a cube GameObject
        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);

        // Create a material and assign the texture to it
        Material cubeMaterial = new Material(Shader.Find("Standard"));
        cubeMaterial.mainTexture = cubeTexture;

        // Assign the material. maybe just combine these two steps later?
        Renderer cubeRenderer = cube.GetComponent<Renderer>();
        cubeRenderer.material = cubeMaterial;

        //why is this necessary? Because unity is crap, thats why
        cube.AddComponent<Hacky>();
        Hacky hacky = cube.GetComponent<Hacky>();
        hacky.AttachObject(letter);

        cube.transform.SetParent(this.transform, true);
        cube.transform.position = new Vector3((row * 1.5f) - 7.5f, (column * 1.5f) - 1.5f, 0f);
        cube.transform.Rotate(new Vector3(0f, 90f, 0f), Space.Self);

        return cube;
    }

    void TestMethod()
    {
        // foreach (GameObject block in grid)
        // {
        //     Hacky blockObj = block.GetComponent<Hacky>();

        //     Debug.Log(blockObj.Letter());
        // }
    }
}


