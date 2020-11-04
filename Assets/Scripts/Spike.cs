using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Spike : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] GameObject effectPrefub;
    [SerializeField] float TimeToDestroyEffect;

    void OnTriggerEnter2D(Collider2D coll)
    {
        var health = coll.GetComponent<Health>();
        if (health)
        {
            health.Value -= damage;
            Bam();
        }
    }

    private void OnTriggerStay2D(Collider2D coll)
    {
        var health = coll.GetComponent<Health>();
        if (health)
        {
            health.Value -= damage;
            Bam();
        }
    }

    void Bam()
    {
        if (!effectPrefub) return;

        var t = Instantiate(effectPrefub, transform.position, Quaternion.identity);
        Destroy(t, TimeToDestroyEffect);
    }
}
