using UnityEngine;
using System.Collections;

public class MenuPanel : MonoBehaviour
{
    public virtual void OnEnable()
    {
        if (PauseManager.InstanceExists)
        {
            PauseManager.Instance.Pause();
            Time.timeScale = 0;
        }
      
    }
    public virtual void OnDisable()
    {
        if (PauseManager.InstanceExists)
        {
            PauseManager.Instance.Resume();
            Time.timeScale = 1;
        }
        
    }
}