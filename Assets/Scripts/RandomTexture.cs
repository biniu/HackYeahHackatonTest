using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RandomTexture : MonoBehaviour
{
    public MeshRenderer plane_renderer;

    public Material[] mats;
    private int count;

    private float timer = 0;
    private bool updatePic = false;

    void Start()
    {
        plane_renderer.GetComponentInChildren<MeshRenderer>();
        count = mats.Length;
        plane_renderer.material = mats[new System.Random().Next(count)];

    }


    void Update()
    {

        if (!updatePic) {
            timer += Time.deltaTime;
        }

        if(timer > 5)
        {
            plane_renderer.material = mats[new System.Random().Next(count)];
            timer = 0;
        }

        

    }
}
