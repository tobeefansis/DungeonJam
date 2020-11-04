using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

public class PlayerSettings : Singleton<PlayerSettings>
{
    [SerializeField] Player player;

    public List<Vector2> DeadPositions => player.DeadPositions;

    public Player Player { get => player; set => player = value; }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        PlayerLoader.OnLoad += n => player = n;
        PlayerLoader.Get();
    }

    public void AddGravePoint(Vector2 pos)
    {
        player.DeadPositions.Add(pos);
    }

    public void AddMoney(int t)
    {
        if (t > player.BestScore)
        {
            player.BestScore = t;
        }
        player.Money += t;

        PlayerSaver.Set(player);
    }
}