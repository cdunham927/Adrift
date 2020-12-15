using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : Teleportable
{
    public enum pickupType { coffee, bomb, coin }
    public pickupType type;

    private void Update()
    {

        if (teleportCools > 0) teleportCools -= Time.deltaTime;
        if (teleportCools <= 0) hasTeleported = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            switch(type)
            {
                case (pickupType.coffee):

                    break;
                case (pickupType.bomb):

                    break;
                case (pickupType.coin):

                    break;
            }
        }
    }
}
