using UnityEngine;
using System.Collections;

public class Wallet : MonoBehaviour
{
    private int value;

    [SerializeField] IntEvent onChange;

    public int Value
    {
        get => value;
        set
        {
            onChange.Invoke(value - this.value);
            this.value = value;
        }
    }

    public IntEvent OnChange { get => onChange; set => onChange = value; }

  
}