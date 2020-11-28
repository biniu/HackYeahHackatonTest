using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour
{
    public float speed = 1.0f;

    void Start()
    {

    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime;
    }
}
