using UnityEngine;


[CreateAssetMenu(fileName = "BlockObject", menuName = "Blocks")]
public class BlockObjects: ScriptableObject
{
    public int points;
    public Texture2D letterTex;
    public char letter;

}