using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : Switchable
{
    public float distanceToPlayer;
    bool inRange = false;
    public float timeBetweenShots;
    public float rotSpd;
    PlayerController player;
    GameController cont;
    public float accuracy = 1f;
    public GameObject bullet;
    public GameObject bulSpawn;
    float cools;
    AudioSource src;
    public AudioClip clip;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerController>();
        cont = FindObjectOfType<GameController>();
    }

    private void Update()
    {
        inRange = ((Vector2.Distance(player.transform.position, transform.position) < distanceToPlayer) && cont.hp > 0);

        if (cont.started && !cont.nextLevelObject.activeInHierarchy)
        {
            if (inRange && on)
            {
                Vector3 diff = transform.position - player.transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0f, 0f, rot_z + 90), rotSpd * Time.deltaTime);

                if (cools > 0) cools -= Time.deltaTime;

                if (cools <= 0)
                {
                    GameObject obj = Instantiate(bullet, bulSpawn.transform.position, transform.rotation * Quaternion.Euler(0, 0, Random.Range(-accuracy, accuracy)));
                    src.PlayOneShot(clip);
                    cools = timeBetweenShots;
                }
            }
        }
        else cools = 0.2f;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distanceToPlayer);
    }
}
