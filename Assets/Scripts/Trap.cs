using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour {

	public GameObject car;
	private Rigidbody m_Rigidbody;
	private bool inArea = false;
    public float slow=0.99f;

	// Use this for initialization
	void Start () {
		m_Rigidbody = car.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(inArea)
			m_Rigidbody.velocity = m_Rigidbody.velocity*slow;
	}

	void OnTriggerEnter(Collider other){
		inArea = true;
		// StartCoroutine(slow());


	}

	void OnTriggerExit(Collider other){
		inArea = false;
	}

	// IEnumerator slow() {
    // while (inArea) {
    //     yield return new WaitForSeconds(0.01f);
	// 	m_Rigidbody.velocity = m_Rigidbody.velocity/10;
		
    // }
// }
}
