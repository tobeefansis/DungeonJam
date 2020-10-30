using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] List<Chanck> chancks = new List<Chanck>();
    [SerializeField] List<Chanck> chanckPrefubs = new List<Chanck>();
    [SerializeField] int maxCount;
    
    void Update()
    {
        if (target.position.y >= chancks[chancks.Count - 1].start.position.y)
        {
            AddChanck();
        }
    }

    private void AddChanck()
    {
        var chanckPrefub = chanckPrefubs[Random.Range(0, chanckPrefubs.Count)];
        var t = Instantiate(
              chanckPrefub,
             chancks[chancks.Count - 1].end.position - chanckPrefub.start.localPosition,
              new Quaternion());
        chancks.Add(t);
        if (chancks.Count > maxCount)
        {
            Destroy(chancks[0].gameObject);
            chancks.RemoveAt(0);
        }
    }
}
