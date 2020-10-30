using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GraveSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> GravePrefubs;

    void Start()
    {
        if (PlayerSettings.InstanceExists)
        {
            foreach (var item in PlayerSettings.Instance.DeadPositions)
            {
                Instantiate(GravePrefubs[Random.Range(0, GravePrefubs.Count)], item, Quaternion.identity);
            }
        }
    }
}