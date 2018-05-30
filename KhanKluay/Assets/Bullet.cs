using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {

	// Use this for initialization
	public string tagName;

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag.Equals(tagName)){
		Destroy(other.gameObject);
		Destroy(gameObject);

		//Debug.Log("fire enemy");
		}
	}
}
