using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switchable : Teleportable
{
    [SerializeField]
    protected bool on;

    public void Switch()
    {
        on = !on;
    }
}
