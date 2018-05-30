using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraContorl : MonoBehaviour {

	GameObject player;
	Vector3 offset;
	void Start () {
		player = FindObjectOfType<playercontrol>().gameObject;
		offset = player.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = player.transform.position - offset;
	}
}
