using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hacky : MonoBehaviour
{
    public BlockObjects blockObject;
    public float spinSpeed = 560f;
    public float duration = 1.5f;
    Vector3 initSize;

    void Start()
    {
        initSize = this.transform.localScale;
    }

    public void AttachObject(BlockObjects block)
    {
        blockObject = block;
    }

    public int Points()
    {
        int point = blockObject.points;
        return point;
    }

    public char Letter()
    {
        return blockObject.letter;
    }

    void Update()
    {
        this.gameObject.GetComponent<Renderer>().material.mainTexture = blockObject.letterTex;
    }

    public void Morte(GridManager gridManager)
    {
        StartCoroutine(SpinCycle(gridManager));
    }

    IEnumerator SpinCycle(GridManager gridManager)
    {
        // Get the position of the destroyed object in the grid
        int row = Mathf.RoundToInt((this.transform.position.x + 7.5f) / 1.5f);
        int column = Mathf.RoundToInt((this.transform.position.y + 1.5f) / 1.5f);

        while (this.transform.localScale.x > 0f)
        {    
            // Spin the object around its y-axis
            this.transform.Rotate(Vector3.up, spinSpeed * Time.deltaTime);

            // Shrink the object by reducing its scale
            this.transform.localScale -= Vector3.one * duration * Time.deltaTime;

            yield return null;
        }

        // Ensure the scale is set to zero to avoid any artifacts
        this.transform.localScale = Vector3.zero;

        // Destroy the game object
        Destroy(this.gameObject);

        // Set the grid cell as empty
        gridManager.SetCellEmpty(row, column);

        // Call FillGrid after the coroutine has finished
        gridManager.FillGrid();
    }
}
