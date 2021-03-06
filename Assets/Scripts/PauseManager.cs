﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseManager : Singleton<PauseManager>
{
    [SerializeField] List<IPause> PauseObjects = new List<IPause>();
    [SerializeField] UnityEvent OnPause;
    [SerializeField] UnityEvent OnResume;

    private void Start()
    {
        Time.timeScale = 1;
        PauseObjects = FindObjectsOfType<GameObject>()
            .Select(n => n.GetComponent<IPause>())
            .Where(n => n != null)
            .ToList();
        PauseObjects.ForEach(n => n.Pause());
        Time.timeScale = 0;
    }

    public void Pause()
    {
        PauseObjects.ForEach(n => n.Pause());
        OnPause.Invoke();
        Time.timeScale = 0;
    }

    public void Resume()
    {
        PauseObjects.ForEach(n => n.Resume());
        OnResume.Invoke();
        Time.timeScale = 1;
    }

    public void Restart()
    {
        SceneManager.LoadScene("Game");
    }
}