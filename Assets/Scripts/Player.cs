using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.Events;


public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    bool isToch;
    public Rigidbody2D rb2d;
    public float speed;
    public HealthSystem healthSystem = new HealthSystem(100);

    public VoidEvent OnDead;
    public IntEvent OnDamaged;
    public GameObject cameraObject;
    public int money;
    public PlayerStaff staff;
    public GameObject main;
    public LineRenderer renderer;
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        healthSystem.OnDamaged += HealthSystem_OnDamaged;
        healthSystem.OnDead += HealthSystem_OnDead;

        Instantiate(staff.selected.skinObject).transform.SetParent(main.transform);
    }
    void Flip() // отражение по горизонтали
    {
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    private void HealthSystem_OnDead()
    {
        OnDead?.Invoke();
    }

    private void HealthSystem_OnDamaged(int obj)
    {
        OnDamaged?.Invoke(obj);

    }

    public void Instate(GameObject gameObject)
    {
        Instantiate(gameObject, transform.position, new Quaternion());
    }

    // Update is called once per frame
    void Update()
    {
        cameraObject.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        if (Input.GetMouseButton(0))
        {
            isToch = true;
            Vector3 vector = transform.position;
            Vector3 vector2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //transform.rotation = Quaternion.Euler(0,0,Vector3.SignedAngle(transform.right, vector2 - vector,  Vector3.forward));

            Vector2 ordinate = new Vector2(0, 1f); //Вектор ординаты, также можно задать его константой Vector2.Up
            Vector2 vecAB = vector2 - vector; //Вектор, заданный двумя точками, чтобы задать вектор двумя точками, надо из точки его конца вычесть точку начала
            float angle = Vector2.Angle(ordinate, vecAB); // Угол между ординатой и вашим вектором


            if (vecAB.x > 0)
            {
                angle *= -1;

                Vector3 theScale = transform.localScale;
                theScale.x = -(1 - Vector3.Distance(vector, vector2) / 40);


                transform.localScale = theScale;
            }
            else
            {
                Vector3 theScale = transform.localScale;
                theScale.x = 1 - Vector3.Distance(vector, vector2) / 40;

                angle -= 180;
                transform.localScale = theScale;
            }
            transform.rotation = Quaternion.Euler(0, 0, angle + 90);


            rb2d.Sleep();



            Ray2D ray = new Ray2D(transform.position, (vector2 - vector) * -1);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction * 10);
            Debug.DrawRay(ray.origin, ray.direction * 10);

            renderer.positionCount = 2;
            renderer.SetPosition(0, transform.position);
            renderer.SetPosition(1, vector+ (vector2 - vector) * -1);
            renderer.enabled = true;

        }
        else
        {
            if (isToch)
            {
                rb2d.WakeUp();
                renderer.enabled = false;
                Vector2 vector = transform.position;
                Vector2 vector2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rb2d.AddForce((vector2 - vector) * speed * -1);
                isToch = false;

                Vector3 theScale = transform.localScale;
                if (theScale.x>0)
                {
                    theScale.x = 1;

                }
                else
                {
                    theScale.x = -1;

                }
                transform.localScale = theScale;
            }
        }


    }

}
