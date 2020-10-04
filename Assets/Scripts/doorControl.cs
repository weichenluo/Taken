using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class doorControl : MonoBehaviour {

	private Animator anim;
    private GameObject[] npcs;
    private int numberOfNPCS;

    // Use this for initialization
    void Start () {
		anim = GetComponent<Animator>();
	}
	
	private void OnTriggerEnter(Collider other)
    {
        npcs = GameObject.FindGameObjectsWithTag("NPC");
        numberOfNPCS = npcs.Length;
        if (numberOfNPCS == 0)
        {
            anim.SetBool("OpenDoor", true);
        }      
    }
}
