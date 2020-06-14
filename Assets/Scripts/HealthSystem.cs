using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class HealthSystem
{
    [SerializeField]
    private int health;
    [SerializeField]
    private int maxHealth;

    public int Health
    {
        get => health;
        set => health = value;
    }
    public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public float GetProcent()
    {

        return health / (float)maxHealth *100f;
    }

    public HealthSystem(int health)
    {
        this.Health = health;

    }

    public event System.Action OnDead;
    public event System.Action<int> OnDamaged;

    public void AddDamahe(int system)
    {
        Health -= system;
        OnDamaged?.Invoke(system);
        if (Health <= 0)
        {
            OnDead?.Invoke();
        }
    }
}
