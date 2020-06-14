using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TochEventObject : MonoBehaviour
{
    public GameObjectEvent OnPlayerEnter;
    public bool DestroyAfterToch;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            OnPlayerEnter?.Invoke(collision.gameObject);
            if (DestroyAfterToch)
            {
                Destroying  (gameObject);
            }
        }

    }
    public  void Destroying(GameObject game)
    {
        Destroy(game);
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
