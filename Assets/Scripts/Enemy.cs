using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Transform waypointA;
    public Transform waypointB;
    public float speed = 1.5f; // скорость движения
    public int damage;
    public GameObjectEvent onCollisionPlayer;
    public bool facingRight = true;
    private Rigidbody2D body;



    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        body.freezeRotation = true;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.transform.tag == "Player")
        {
            Destroy(gameObject);
        }

    }


    void FixedUpdate()
    {
        if (gameObject.transform.position.x <= waypointB.position.x)
        {
            facingRight = true;
            Flip();
        }
        if (gameObject.transform.position.x >= waypointA.position.x)
        {
            facingRight = false;
            Flip();
        }

        MakePosition();
    }

    void MakePosition()
    {
        if (facingRight)
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
        }
    }

    void Flip() // отражение по горизонтали
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }


    public void GenerateWaypoints(GameObject point) // вспомогательная функция для создания вейпоинтов
    {
        if (!waypointA && !waypointB)
        {
            GameObject obj = new GameObject(gameObject.name + "_Waypoints");
            obj.transform.position = transform.position;

            GameObject clone = Instantiate(point) as GameObject;
            clone.transform.parent = obj.transform;
            clone.transform.localPosition = new Vector2(3, 0);
            clone.name = "Point_A";
            waypointA = clone.transform;

            clone = Instantiate(point) as GameObject;
            clone.transform.parent = obj.transform;
            clone.transform.localPosition = new Vector2(-3, 0);
            clone.name = "Point_B";
            waypointB = clone.transform;
        }
    }

}
