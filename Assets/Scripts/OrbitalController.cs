using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitalController : Switchable
{
    public float orbitalSpeed = .20f;
    float orbitalAngle = 0.0f;
    float orbitalRotationalSpeed = 20;
    public float distanceToCenter = 5;
    public Vector2 center;
    public float startAngle;
    GameController cont;

    private void Awake()
    {
        cont = FindObjectOfType<GameController>();
        center = Vector2.zero;
    }

    public void Move()
    {
        Vector2 lookPos = center;
        Vector2 direction = (lookPos - (Vector2)transform.position).normalized;
        transform.up = direction;


        if (cont.started)
        {
            orbitalAngle += Time.deltaTime * orbitalSpeed;
        }

        float tempx, tempy;

        tempx = center.x + distanceToCenter * Mathf.Cos(orbitalAngle + (startAngle * Mathf.PI / 180));
        tempy = center.y + distanceToCenter * Mathf.Sin(orbitalAngle + (startAngle * Mathf.PI / 180));

        transform.position = new Vector3(tempx, tempy, transform.position.z);
    }
}
