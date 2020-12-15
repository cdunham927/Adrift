using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoosterController : Switchable
{
    public float boostSpd;
    AudioSource src;
    public AudioClip clip;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (on)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Other") || collision.CompareTag("Drone"))
            {
                src.PlayOneShot(clip);
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (on)
        {
            if (collision.CompareTag("Player") || collision.CompareTag("Other") || collision.CompareTag("Drone"))
            {
                collision.GetComponent<Rigidbody2D>().AddForce(transform.up * boostSpd);
            }
        }
    }
}
