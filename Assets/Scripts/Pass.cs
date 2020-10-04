using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pass : MonoBehaviour
{
    public GameObject optionCanvas;

    private void OnTriggerEnter(Collider other)
    {
        //optionCanvas = GameObject.FindGameObjectWithTag("OptionCanvas");
        MenuUI script = optionCanvas.GetComponent<MenuUI>();
        script.pass = true;
    }
}
