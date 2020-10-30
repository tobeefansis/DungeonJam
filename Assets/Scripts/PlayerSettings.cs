using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerSettings : Singleton<PlayerSettings>
{
    Player player;

    public List<Vector2> DeadPositions => player.DeadPositions;

    public void AddGravePoint(Vector2 pos)
    {
        player.DeadPositions.Add(pos);
    }

    public void AddMoney(int t)
    {
        player.Money += t;
    }
}