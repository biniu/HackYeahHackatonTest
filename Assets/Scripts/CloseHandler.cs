using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseHandler : MonoBehaviour
{

    void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Application.Quit();
        }
    }


}
