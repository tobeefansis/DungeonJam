using UnityEngine;
using System.Collections;

public class PlayerHealth : Health
{
    private void Start()
    {
        OnDead.AddListener(AddGravePoint);
        OnDead.AddListener(PauseManager.Instance.Pause);
    }

    private void AddGravePoint()
    {
        if (PlayerSettings.InstanceExists)
        {
            PlayerSettings.Instance.AddGravePoint(transform.position);
        }
    }
}