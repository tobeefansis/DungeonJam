using UnityEngine;
using System.Collections;

public class PauseMenu : MenuPanel
{
    [SerializeField] Bar scoreBar;
    [SerializeField] Bar distanceBar;

    public override void OnEnable()
    {
        base.OnEnable();
        scoreBar.SetValue(124,0.5f);
    }
}