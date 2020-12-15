using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportable : MonoBehaviour
{
    [SerializeField]
    protected bool hasTeleported = false;
    protected float teleportCools = 0f;
    public float timeToTeleport = 0.3f;

    public void SetTeleport()
    {
        hasTeleported = true;
        teleportCools = timeToTeleport;
    }

    public void ResetTeleport()
    {
        hasTeleported = false;
        CancelInvoke();
    }

    public bool CheckTeleported()
    {
        return hasTeleported;
    }
}
