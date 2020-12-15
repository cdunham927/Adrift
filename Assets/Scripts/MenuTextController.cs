using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuTextController : MonoBehaviour
{
    Vector3 startPos;

    public float amplitude = 10f;
    public float period = 5f;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        float theta = Time.timeSinceLevelLoad / period;
        float distance = amplitude * Mathf.Sin(theta);
        transform.position = startPos + Vector3.up * distance;
    }

    public void LoadLevel(int index)
    {
        SceneManager.LoadScene(index);
    }
}
