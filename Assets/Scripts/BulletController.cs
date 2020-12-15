using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : Teleportable
{
    public float spd;
    Rigidbody2D bod;
    public float force;

    void Awake()
    {
        bod = GetComponent<Rigidbody2D>();
    }

    void Update()
    {

        if (teleportCools > 0) teleportCools -= Time.deltaTime;
        if (teleportCools <= 0) hasTeleported = false;
    }

    // Use this for initialization
    void OnEnable()
    {
        Invoke("Disable", 4f);
        bod.AddForce(transform.up * spd);
    }

    void OnDisable()
    {
        CancelInvoke();
    }

    void Disable()
    {
        //GameObject obj = GameController.instance.GetBulletDestroyObj();
        //obj.transform.position = transform.position;
        //obj.transform.rotation = transform.rotation;
        //obj.SetActive(true);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") || other.CompareTag("Other"))
        {
            Rigidbody2D thatBod = other.gameObject.GetComponent<Rigidbody2D>();
            if (thatBod != null) thatBod.AddForceAtPosition(transform.up * force, transform.position);
            Invoke("Disable", 0.01f);
        }
    }
}
