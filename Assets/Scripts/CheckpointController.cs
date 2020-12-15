using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    public CheckpointController nextCheckpoint;
    GameController cont;
    public float timeAdd = 5f;
    PlayerController player;
    public bool lastCheckpoint = false;
    AudioSource src;
    public AudioClip endClip;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
        cont = FindObjectOfType<GameController>();
        player = FindObjectOfType<PlayerController>();
    }

    private void OnEnable()
    {
        player.curCheckpoint = this;
        if (nextCheckpoint == null) lastCheckpoint = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (nextCheckpoint != null)
            {
                cont.AddTime(timeAdd);
                nextCheckpoint.gameObject.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                player.DeactivateArrow();
                cont.ended = true;
                cont.EndScreen();
                src.PlayOneShot(endClip);
            }
        }
    }
}
