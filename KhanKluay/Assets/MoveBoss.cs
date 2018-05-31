using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBoss : MonoBehaviour {

	public GameObject Bullet, realBullet;
	Transform post;
	Rigidbody2D moveMent;
	Animator fact;
	float timeOut, coolDown = 5;

	private float jump = 0f;

	private int distance = -1;

	void Start () {
		post=GetComponent<Transform>();
		moveMent=GetComponent<Rigidbody2D>();
		fact=GetComponent<Animator>();

	}

	void OnTriggerStay2D(Collider2D coll)
	{
        if (coll.gameObject.CompareTag("Player") && (Time.time >= timeOut+coolDown)) {
			int i = 1;
			//Debug.Log("shoot");
			while(i != 5){
				realBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
				realBullet.GetComponent<Rigidbody2D>().velocity = new Vector2((10f+i)*distance,i-2);
				Debug.Log(realBullet.transform.position);
				Destroy(realBullet, 6);
				i += 1;
			}
			timeOut = Time.time;
		}
    }
	void Update () {
		if(gameObject.transform.position.x <= -42){  
			fact.SetBool("isRight", true);
			distance = 1;

		}else if(gameObject.transform.position.x >= 50){
			Debug.Log("back");
			fact.SetBool("isRight", false);
			distance = -1;
		}
		moveMent.velocity = new Vector2(12f*distance, 0);
	}

}
