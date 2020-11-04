using UnityEngine;
using System.Collections;
using System;

public class Coin : TochEventObject
{
    [SerializeField] int count;

    void Start()
    {
        OnPlayerEnter.AddListener(AddCoin);
    }

    private void AddCoin(GameObject obj)
    {
        var wallet = obj.GetComponent<Wallet>();
        if (wallet)
        {
            wallet.Value += count;
        }
    }
}