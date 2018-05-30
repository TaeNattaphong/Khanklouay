using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemLife : MonoBehaviour {

	Collider2D c;
	// Use this for initialization
	void Start () {
		c = GetComponent<Collider2D>();
		c.isTrigger = true;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		Text tt;
		tt = GameObject.Find("/Canvas showVeiw/Life").GetComponent<Text>();
		GameContorler.numLife++;
		tt.text = "Life = " + GameContorler.numLife;
		Destroy(gameObject);
	}
}
