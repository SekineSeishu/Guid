using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Character", menuName = "ScriptableObjects/MoveDirections", order = 1)]
public class MoveDirections : ScriptableObject
{
    [Header("レッド")]
    public bool redUp;
    public bool redDown;
    public bool redLeft;
    public bool redRight;
    public bool redUpLeft;
    public bool redUpRight;
    public bool redDownLeft;
    public bool redDownRight;
    [Space(20)]
    [Header("ブルー")]
    public bool buleUp;
    public bool buleDown;
    public bool buleLeft;
    public bool buleRight;
    public bool buleUpLeft;
    public bool buleUpRight;
    public bool buleDownLeft;
    public bool buleDownRight;

    public List<Vector3> GetValidMove(string character, float xPos, float zPos)
    {
        List<Vector3> validMoves = new List<Vector3>();
        if (character == "red")
        {
            if (redUp)
                validMoves.Add(new Vector3(xPos, 0.5f, zPos + 1));
            if (redDown)
                validMoves.Add(new Vector3(xPos, 0.5f, zPos - 1));
            if (redLeft)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos));
            if (redRight)
                validMoves.Add(new Vector3(xPos + 1, 0.5f, zPos));
            if (redUpLeft)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos + 1));
            if (redUpRight)
                validMoves.Add(new Vector3(xPos + 1, 0.5f, zPos + 1));
            if (redDownLeft)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos - 1));
            if (redDownRight)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos + 1));
        }
        if (character == "blue")
        {
            if (buleUp)
                validMoves.Add(new Vector3(xPos, 0.5f, zPos + 1));
            if (buleDown)
                validMoves.Add(new Vector3(xPos, 0.5f, zPos - 1));
            if (buleLeft)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos));
            if (buleRight)
                validMoves.Add(new Vector3(xPos + 1, 0.5f, zPos));
            if (buleUpLeft)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos + 1));
            if (buleUpRight)
                validMoves.Add(new Vector3(xPos + 1, 0.5f, zPos + 1));
            if (buleDownLeft)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos - 1));
            if (buleDownRight)
                validMoves.Add(new Vector3(xPos - 1, 0.5f, zPos + 1));
        }
        return validMoves;
    }
}
