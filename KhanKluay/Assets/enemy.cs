using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {

	Rigidbody2D en;
	public bool walkRight;

	private Vector3 spwanPosition;

	private Vector2 playerPosition;
	
	public float startWalk;
	Vector3 eni;
	public float distance = 1.0f;

	public bool isFoundPlayer = false;

	private float currentPlayer;


	void Start () {
		en = GetComponent<Rigidbody2D>();
		walkRight = true;
		spwanPosition = gameObject.transform.position;
		currentPlayer = en.transform.position.x;
	}
	

	void Update () {

		float jump = 0f;

		if (spwanPosition.x + startWalk <= gameObject.transform.position.x || playerPosition.x - en.transform.position.x < 1){
			walkRight = false;
			distance = -1;
		}

		else if (spwanPosition.x - startWalk >= gameObject.transform.position.x  ||playerPosition.x - en.transform.position.x >= 1){
			walkRight = true;
			distance = 1;
		}

		if(isFoundPlayer && Mathf.Abs(currentPlayer - en.transform.position.x) >= 0.01f){
			jump = 10.0f * Time.deltaTime;
		}
		en.transform.Translate(new Vector3(5.0f * Time.deltaTime * distance, jump));
		currentPlayer = en.transform.position.x;
		
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
		// 	}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player") {
			isFoundPlayer = true;
			playerPosition = other.transform.position;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if(other.tag == "Player") {
			isFoundPlayer = true;
			playerPosition = other.transform.position;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if(other.tag == "Player") {
			isFoundPlayer = false;
		}
	}
}
