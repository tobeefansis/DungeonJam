using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Generator : MonoBehaviour
{
    public List<Chanck> chancks = new List<Chanck>();
    public List<Chanck> chanckPrefubs = new List<Chanck>();
    public int maxCount;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.player.position.x >= chancks[chancks.Count - 1].start.position.x)
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
        if (chancks.Count> maxCount)
        {
            Destroy(chancks[0].gameObject);
            chancks.RemoveAt(0);
        }
    }
}
