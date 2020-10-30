using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;


public class GameManager : Singleton<GameManager>
{
    [SerializeField] UnityEvent OnLose;

    public void Lose()
    {
        print("///Lose///");
        OnLose.Invoke();
    }
}