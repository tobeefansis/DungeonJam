using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Player
{
    [SerializeField] int money;
    [SerializeField] int bestScore;
    [SerializeField] List<Vector2> deadPositions = new List<Vector2>(); 

    public int Money { get => money; set => money = value; }
    public List<Vector2> DeadPositions { get => deadPositions; set => deadPositions = value; }
    public int BestScore { get => bestScore; set => bestScore = value; }
}