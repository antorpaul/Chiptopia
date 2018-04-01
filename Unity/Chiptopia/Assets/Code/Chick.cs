using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chick : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player1" || other.gameObject.tag == "Player2")
		{
			Destroy(gameObject);
		}
	}
}
