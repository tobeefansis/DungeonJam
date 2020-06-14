using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
	public int damage;
	public GameObject BamObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }
	void OnTriggerEnter2D ( Collider2D coll )
	{
		if ( !coll.isTrigger ) // чтобы пуля не реагировала на триггер
		{
			switch ( coll.tag )
			{
				case "Player":
					coll.GetComponent<Player> ( ).healthSystem.AddDamahe ( damage );
					print("bam");
					Bam();
					break;
				case "Enemy_2":
					// что-то еще...
					break;
			}

		}
	}
	void Bam()
	{
		BamObject.SetActive(true);
	}
	// Update is called once per frame
	void Update()
    {
        
    }
}
