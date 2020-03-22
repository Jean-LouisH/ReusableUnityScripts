using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escape_To_Quit : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
