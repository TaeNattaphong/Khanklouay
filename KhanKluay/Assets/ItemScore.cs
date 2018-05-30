using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemScore : MonoBehaviour {

	Collider2D c;
	// Use this for initialization
	void Start () {
		c = GetComponent<Collider2D>();
		c.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Text t;
		t = GameObject.Find("/Canvas showVeiw/Score").GetComponent<Text>();
		GameContorler.numScore += 10;
		t.text = "Score: " + GameContorler.numScore;
		Destroy(gameObject);
	}
}
