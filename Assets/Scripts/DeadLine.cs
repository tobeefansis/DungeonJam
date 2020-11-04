using UnityEngine;
using System.Collections;
using DG.Tweening;

public class DeadLine : MonoBehaviour
{
    [SerializeField] float maxDistance;
    [SerializeField] Transform Target;
    [SerializeField] float time = .3f;
    [SerializeField] float speed = 2;
    Transform _transform;

    private void Awake()
    {
        _transform = transform;
    }

    private void FixedUpdate()
    {
        var distance = Target.position.y - _transform.position.y;
        if (distance > maxDistance)
        {
            _transform.DOMoveY(Target.position.y - maxDistance, time);
        }
        else
        {
            _transform.Translate(Vector2.up * speed * Time.fixedDeltaTime);
        }
    }
}