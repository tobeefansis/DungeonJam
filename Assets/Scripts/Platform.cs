using System;

using UnityEngine;

class Platform : TochEventObject
{
    public int TochCount;
    public int MaxTochCount;

    private void Start()
    {
        OnPlayerEnter.AddListener(Step);
    }

    private void Step(GameObject obj)
    {

        TochCount++;
        if (TochCount >= MaxTochCount)
        {
            Destroy(gameObject);
        }
    }
}