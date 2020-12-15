using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidController : Teleportable
{
    private void OnEnable()
    {
        float sc = Random.Range(1f, 1.75f);
        transform.localScale = new Vector3(sc, sc, 1);
        transform.rotation = Quaternion.Euler(0, 0, Random.Range(0, 360));
    }

    private void Update()
    {

        if (teleportCools > 0) teleportCools -= Time.deltaTime;
        if (teleportCools <= 0) hasTeleported = false;
    }
}
