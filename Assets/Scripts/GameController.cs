using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool started = false;
    public float startHp = 10f;
    public float hp;
    public Image hpImage1;
    public Image hpImage2;
    public float lerpSpd;
    public bool ended = false;
    public Text hpText;
    public Text timeAddText;
    public List<GameObject> timeAddList = new List<GameObject>();
    public GameObject nextLevelObject;
    public GameObject resetObject;
    public GameObject startObject;
    AudioSource src;
    public AudioClip clip;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
        hp = startHp;
    }

    private void Update()
    {

        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (!started)
        {
            if (Input.GetAxisRaw("Vertical") > 0)
            {
                startObject.SetActive(false);
                started = true;
            }
        }

        hpImage1.fillAmount = Mathf.Lerp(hpImage1.fillAmount, (hp / startHp), Time.deltaTime * lerpSpd);
        hpImage2.fillAmount = Mathf.Lerp(hpImage2.fillAmount, (hp / startHp), Time.deltaTime * lerpSpd);
        hpText.text = "Fuel remaining: " + Mathf.Round(hp * 10).ToString();

        if (hp <= 0) ended = true;
    }

    public void AddTime(float amt)
    {
        if ((hp + amt) < startHp) hp += amt;
        else hp = startHp;

        src.PlayOneShot(clip);
    }

    public void EndScreen()
    {
        nextLevelObject.SetActive(true);
    }

    public void ResetScreen()
    {
        resetObject.SetActive(true);
    }

    public void NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
