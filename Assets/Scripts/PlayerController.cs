using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : Teleportable
{
    GameController cont;
    public float spd;
    Rigidbody2D bod;
    Vector2 inp;
    public float rotSpd;
    [HideInInspector]
    public CheckpointController curCheckpoint;
    public GameObject arrow;
    public GameObject arrowChild;
    public float lerpSpd = 10f;
    public Vector3 offset;
    public Text distanceText;
    //Animator anim;
    public bool credits = false;
    AudioSource src;
    public AudioClip[] clip;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
        cont = FindObjectOfType<GameController>();
        bod = GetComponent<Rigidbody2D>();
        //anim = GetComponent<Animator>();

        if (!credits) arrowChild = Instantiate(arrow, new Vector3(transform.position.x, transform.position.y + 1f, 0f), Quaternion.identity);
    }

    private void FixedUpdate()
    {
        inp = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        if (cont.started && !cont.nextLevelObject.activeInHierarchy && cont.hp > 0)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W))
            {
                src.PlayOneShot(clip[Random.Range(0, clip.Length)]);
            }
            if (inp.y > 0)
            {
                cont.hp -= Time.deltaTime;
                bod.AddForce(transform.up * spd * Time.deltaTime);
                //anim.SetBool("moving", true);
            }
            //else anim.SetBool("moving", false);

            if (inp.x != 0)
            {
                transform.Rotate(0, 0, -inp.x * rotSpd * Time.deltaTime);
            }
            if (curCheckpoint != null)
            {
                Vector3 diff = transform.position - curCheckpoint.transform.position;
                diff.Normalize();

                float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
                arrowChild.transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
                //distanceText.text = Mathf.Round(Vector2.Distance(transform.position, curCheckpoint.transform.position)).ToString();
            }

            if (teleportCools > 0) teleportCools -= Time.deltaTime;
            if (teleportCools <= 0) hasTeleported = false;
        }

        if (curCheckpoint != null) arrowChild.transform.position = transform.position + offset;

        if (cont.ended)
        {
            if (cont.hp > 0)
            {
                cont.ended = false;
                bod.drag = 0;
            }
            bod.drag = 2;

            if (bod.velocity == Vector2.zero && !cont.nextLevelObject.activeInHierarchy)
            {
                cont.ResetScreen();
            }
        }
    }

    public void DeactivateArrow()
    {
        arrowChild.SetActive(false);
    }
}
