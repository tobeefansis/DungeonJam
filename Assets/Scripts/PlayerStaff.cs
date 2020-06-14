using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu()]
public class PlayerStaff : ScriptableObject
{
    public int money;
    public List<Skin> skins = new List<Skin>();
    public Skin selected;
    public int localMoney;

    public int selectIndex;
    public void AddLoaclMoney(int t)
    {
        localMoney += t;
    }
    public void Next()
    {
        selectIndex++;
        if (selectIndex >= skins.Count)
        {
            selectIndex = 0;
        }
        selected = skins[selectIndex];
    }
    public void Back()
    {
        selectIndex--;
        if (selectIndex < 0)
        {
            selectIndex = skins.Count - 1;
        }
        selected = skins[selectIndex];
    }
    public void Buy()
    {
        if (money >= selected.cost && !selected.byed)
        {
            money -= selected.cost;
            selected.byed = true;
        }
    }
    public Skin GetSelectSprite()
    {
        return skins[selectIndex];
    }
    public Skin GetNextSprite()
    {
        int t = selectIndex + 1;
        if (t >= skins.Count)
        {
            t = 0;
        }
        return skins[t];
    }
    public Skin GetBackSprite()
    {
        int t = selectIndex - 1;
        if (t < 0)
        {
            t = skins.Count - 1;
        }
        return skins[t];
    }
}
