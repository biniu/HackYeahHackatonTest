using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;

public class FloorGenerator : MonoBehaviour
{
    public GameObject[] prefabs = new GameObject[3];
    public List<GameObject> FloorObject = new List<GameObject>();

    private int floorCount = 2; 
    
    // public GameObject[] FloorObject = new GameObject[2];
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log("FloorGenerator Update transform.position.x           " + transform.position.x);
        Debug.Log("FloorGenerator Update Camera.main.transform.position " + Camera.main.transform.position);
        //
        Debug.Log("FloorGenerator Update FloorObject.Count " + FloorObject.Count);

        Debug.Log("FloorGenerator Update FloorObject.transform.position.x -1   " + FloorObject[floorCount-1].transform.localPosition.x);
        Debug.Log("FloorGenerator Update FloorObject.transform.position.x -2   " + FloorObject[floorCount-2].transform.position.x);
        
        if ((Camera.main.transform.position.x > FloorObject[FloorObject.Count - 2].transform.position.x) && true)
            // (Camera.main.transform.position.x < FloorObject[FloorObject.Count - 1].transform.position.x))
        {
            Debug.Log("FloorGenerator Update adding new FloorObject");
            Debug.Log("FloorGenerator Update FloorObject.Length B " + FloorObject.Count);

            FloorObject.Add(prefabs[Random.Range(0, prefabs.Length)]);
            
            // FloorObject.Add(prefabs[0]);

            Debug.Log("FloorGenerator Update FloorObject.Length A " + FloorObject.Count);
            
            Instantiate(FloorObject[FloorObject.Count - 1],
                // new Vector3(FloorObject[FloorObject.Count - 1].transform.position.x + 16, 1, 0),
                new Vector3(floorCount * 8, 1, 0),
                Quaternion.identity);

            floorCount++;
            Debug.Log("FloorGenerator Update FloorObject.Length " + FloorObject.Count);
        }
        
        // Debug.Log("FloorGenerator Update FloorObject.Length " + FloorObject.Length);
        
        // Instantiate(prefabs[Random.Range(0, prefabs.Length)], new Vector3(transform.position.x + 16, 1, 0), Quaternion.identity);
        
    }
}