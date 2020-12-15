using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchController : Teleportable
{
    public Switchable toSwitch;
    float switchCools;
    public Sprite[] switchSprites;
    SpriteRenderer rend;
    public bool multipleFlips = true;
    bool hasFlipped = false;

    private void Awake()
    {
        rend = GetComponentInParent<SpriteRenderer>();
    }

    public void Switch()
    {
        toSwitch.Switch();
        hasFlipped = true;
    }

    private void Update()
    {
        if (switchCools > 0) switchCools -= Time.deltaTime;

        if (teleportCools > 0) teleportCools -= Time.deltaTime;
        if (teleportCools <= 0) hasTeleported = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (switchCools <= 0)
        {
            if (multipleFlips || !hasFlipped)
            {
                Switch();
                //Switch sprites when hit
                rend.sprite = (rend.sprite == switchSprites[0]) ? switchSprites[1] : switchSprites[0];
                switchCools = 0.2f;
            }
        }
    }
}
