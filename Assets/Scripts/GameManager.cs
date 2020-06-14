using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

[System.Serializable] public class VoidEvent : UnityEvent { }
[System.Serializable] public class BoolEvent : UnityEvent<bool> { }
[System.Serializable] public class IntEvent : UnityEvent<int> { }
[System.Serializable] public class StringEvent : UnityEvent<string> { }
[System.Serializable] public class GameObjectEvent : UnityEvent<GameObject> { }
public class GameManager : MonoBehaviour
{
    private static Transform _player;
    public VoidEvent EndGame;
    public PlayerStaff staff;

    public void LoadScene(string str)
    {
        SceneManager.LoadScene(str);

    }
    public void LoadScene(int id)
    {
        SceneManager.LoadScene(id);

    }
    void Awake()
    {
        if (staff)
        {

            staff.money += staff.localMoney;
            staff.localMoney = 0;
        }
        var t = GameObject.FindGameObjectWithTag("Player");
        if (t)
        {
            _player = t.transform;

        }
    }
    public static Transform player
    {
        get { return _player; }
    }
}