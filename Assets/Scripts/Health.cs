using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField] int value;
    [SerializeField] int maxValue;
    [SerializeField] UnityEvent onDead;
    [SerializeField] IntEvent onAddDamage;
    [SerializeField] IntEvent onAddHealth;

    public int Value
    {
        get => value;
        set
        {
            if (value > this.value)
            {
                var t = value - this.value;
                onAddHealth.Invoke(t);
            }
            else
            {
                var t = value - this.value;
                onAddDamage.Invoke(t);
            }

            if (value > MaxValue)
            {
                this.value = maxValue;
            }
            else
            {
                this.value = value;
                if (value < 0)
                {
                    OnDead.Invoke();
                   
                    this.value = 0;
                }
            }

        }
    }

   

    public int MaxValue { get => maxValue; set => maxValue = value; }
    public UnityEvent OnDead { get => onDead; set => onDead = value; }
    public IntEvent OnAddDamage { get => onAddDamage; set => onAddDamage = value; }
    public IntEvent OnAddHealth { get => onAddHealth; set => onAddHealth = value; }

   

    public void AddDamage(int damage)
    {
        Value -= damage;
    }
}
