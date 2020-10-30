using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class Movment : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] bool isToch;
    [SerializeField] float speed;
    [SerializeField] Vector2 pos;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    void FixedUpdate()
    {
        if (Input.touchCount > 0)
        {
            pos = Input.GetTouch(0).position;

            isToch = true;
            Vector3 vector = transform.position;
            Vector3 vector2 = Camera.main.ScreenToWorldPoint(pos);

            Vector2 ordinate = new Vector2(0, 1f);
            Vector2 vecAB = vector2 - vector;
            float angle = Vector2.Angle(ordinate, vecAB);

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

            rb.Sleep();
            Ray2D ray = new Ray2D(transform.position, (vector2 - vector) * -1);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction * 10);
            Debug.DrawRay(ray.origin, ray.direction * 10);

            lineRenderer.positionCount = 2;
            lineRenderer.SetPosition(0, transform.position);
            lineRenderer.SetPosition(1, vector + (vector2 - vector) * -1);
            lineRenderer.enabled = true;

        }
        else
        {
            if (isToch)
            {
                rb.WakeUp();
                GetComponent<Renderer>().enabled = false;
                Vector2 vector = transform.position;
                Vector2 vector2 = Camera.main.ScreenToWorldPoint(pos);
                rb.AddForce((vector2 - vector) * speed * -1);
                isToch = false;

                Vector3 theScale = transform.localScale;
                if (theScale.x > 0)
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
