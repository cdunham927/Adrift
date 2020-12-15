using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : Teleportable
{
    SpriteRenderer rend;
    public Sprite onSprite;
    public Sprite offSprite;
    public bool on = false;

    public DoorController door;

    private void Awake()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {

        if (teleportCools > 0) teleportCools -= Time.deltaTime;
        if (teleportCools <= 0) hasTeleported = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Other"))
        {
            rend.sprite = onSprite;
            //door.open = true;
            on = true;
        }
    }
}
