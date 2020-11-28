
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorTile : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[3];
    
    void Start()
    {
        Debug.Log("FloorTile START ");
        Debug.Log("FloorTile START transform.position.x " + transform.position.x);
        
        // Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(transform.position.x + 8, 1, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("FloorTile START ");
        // Debug.Log("FloorTile START transform.position.x           " + transform.position.x);
        // Debug.Log("FloorTile START Camera.main.transform.position " + Camera.main.transform.position);
        //
        // if (Camera.main.transform.position.x + 8 < transform.position.x)
        // {
        //     // Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(transform.position.x + 16, 1, 0),
        //     //     Quaternion.identity);
        // }
    }
}