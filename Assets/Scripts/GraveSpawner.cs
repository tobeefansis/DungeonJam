using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraveSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> GravePrefubs;
    [SerializeField] List<GameObject> GravePrefubs2;

    void Start()
    {
        print("asdasdasdasd2");
        foreach (var item in PlayerSettings.Instance.DeadPositions)
        {
            print("asdasdasdasd");
            GravePrefubs2.Add(Instantiate(GravePrefubs[Random.Range(0, GravePrefubs.Count)], item, Quaternion.identity));
        }
        print("asdasdasdasd4324");
    }
}