using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalController : Switchable
{
    public PortalController otherPortal;
    //public bool isTeleporting = false;
    //public float teleporterCooldown = 3f;
    Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (on)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Other") || collision.CompareTag("Drone") || collision.CompareTag("Bullet"))
            {
                Teleportable tel = collision.GetComponent<Teleportable>();
                if (!tel.CheckTeleported())
                {
                    tel.SetTeleport();
                    collision.transform.position = otherPortal.transform.position;
                }
                //Invoke("ResetCooldown", teleporterCooldown);
            }
        }
        else
        {
            if (otherPortal.on) otherPortal.on = false;
        }

        anim.SetBool("On", on);
    }

    void ResetCooldown()
    {
        //otherPortal.isTeleporting = false;
        //isTeleporting = false;
    }
}
