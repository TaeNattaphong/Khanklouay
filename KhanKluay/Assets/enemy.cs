using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	Rigidbody2D en;
	public bool walkRight;

	private Vector3 spwanPosition;
	
	public float startWalk;
	Vector3 eni;
	public float distance = 1.0f;
	void Start () {
		en = GetComponent<Rigidbody2D>();
		walkRight = true;
		spwanPosition = gameObject.transform.position;
	}
	

	void Update () {
		if (spwanPosition.x - startWalk >= gameObject.transform.position.x) {
			walkRight = true;
			distance = 1;
		}

		else if (spwanPosition.x + startWalk <= gameObject.transform.position.x){
			walkRight = false;
			distance = -1;
		}
		en.transform.Translate(new Vector3(10.0f * Time.deltaTime * distance, 0f));
		
		// 	eni.x = en.transform.position.x;
		// 	en.transform.Translate(new Vector3(10.0f * Time.deltaTime, 0f));
		// 	if (Mathf.Abs(en.transform.position.x)-Mathf.Abs(eni.x) > distance * 1) {
		// 		walkRight = false;
		// 	}
		// }else {
		// 	eni.x = en.transform.position.x;
		// 	en.transform.Translate(new Vector3(-10.0f * Time.deltaTime, 0f));
		// 	if (Mathf.Abs(en.transform.position.x)-Mathf.Abs(eni.x) > distance * 1) {
		// 		walkRight = false;
		// 	}	`
	}
}
