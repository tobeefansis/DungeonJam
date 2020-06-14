using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Timer : MonoBehaviour
{
    public float timeToDestroy;
    public float time;
    public VoidEvent _do;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= timeToDestroy)
        {
            time = 0;
            _do?.Invoke();
        }
    }
}
