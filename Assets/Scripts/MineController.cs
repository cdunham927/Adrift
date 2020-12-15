using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineController : Teleportable
{
    public float expForce = 10;
    Animator anim;
    public AnimationClip animClip;
    AudioSource src;
    public AudioClip clip;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {


        if (teleportCools > 0) teleportCools -= Time.deltaTime;
        if (teleportCools <= 0) hasTeleported = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<GameController>().hp -= 1;
            collision.GetComponent<Rigidbody2D>().AddForceAtPosition(-collision.gameObject.transform.up * expForce, collision.ClosestPoint(transform.position));
            anim.Play("Explode");
            src.PlayOneShot(clip);
            Destroy(gameObject, animClip.length);
        }
        if (collision.CompareTag("Other"))
        {
            collision.GetComponent<Rigidbody2D>().AddForceAtPosition(-collision.gameObject.transform.up * expForce, collision.ClosestPoint(transform.position));
            anim.Play("Explode");
            src.PlayOneShot(clip);
            Destroy(gameObject, animClip.length);
        }
        if (collision.CompareTag("Drone"))
        {
            collision.GetComponent<DroneController>().Die();
            anim.Play("Explode");
            src.PlayOneShot(clip);
            Destroy(gameObject, animClip.length);
        }
    }
}
