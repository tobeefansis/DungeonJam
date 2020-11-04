using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;


public class SmartCam : MonoBehaviour
{
    [SerializeField] Transform Target;
    Transform Cam;
    [SerializeField] Vector3 offset;
    private void Awake()
    {
        Cam = transform;
    }

    private void FixedUpdate()
    {
        var pos = (Vector3)Vector2.Lerp(Cam.position, Target.position, 0.3f) + offset;
        pos.x = 0;
        Cam.position = pos;
    }
}