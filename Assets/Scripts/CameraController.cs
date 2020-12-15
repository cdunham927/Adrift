using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    public float lerpSpd = 10;

    private void Awake()
    {
        target = FindObjectOfType<PlayerController>().transform;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(target.position.x, target.position.y, -10f), Time.deltaTime * lerpSpd);
    }
}
