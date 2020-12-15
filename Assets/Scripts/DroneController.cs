using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneController : Switchable
{
    PlayerController player;
    GameController cont;
    Rigidbody2D bod;
    public float distanceToPlayer;
    bool inRange = false;
    public float timeBetweenShots;
    public float rotSpd;
    public float accuracy = 1f;
    public GameObject bullet;
    public GameObject bulSpawn;
    float cools;
    AudioSource src;
    public AudioClip clip;
    public float spd;
    Animator anim;
    public AnimationClip animClip;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerController>();
        cont = FindObjectOfType<GameController>();
        bod = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        inRange = ((Vector2.Distance(player.transform.position, transform.position) < distanceToPlayer) && cont.hp > 0);

        if (cont.started && !cont.nextLevelObject.activeInHierarchy)
        {
            if (teleportCools > 0) teleportCools -= Time.deltaTime;
            if (teleportCools <= 0) hasTeleported = false;

            if (inRange && on)
            {
                Vector3 diff = transform.position - player.transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z - 90), rotSpd * Time.deltaTime);

                //Move towards player
                bod.AddForce(-transform.up * spd * Time.deltaTime);

                if (cools > 0) cools -= Time.deltaTime;

                if (cools <= 0)
                {
                    Shoot();
                }
            }
        }
    }

    public void Die()
    {
        anim.Play("DroneExplode");
        Invoke("Disable", animClip.length);
    }

    void Disable()
    {
        gameObject.SetActive(false);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Shoot()
    {
        GameObject obj = Instantiate(bullet, bulSpawn.transform.position, transform.rotation * Quaternion.Euler(0, 0, 180 + Random.Range(-accuracy, accuracy)));
        src.PlayOneShot(clip);
        cools = timeBetweenShots;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToPlayer);
    }
}
