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

	}

	void OnTriggerStay2D(Collider2D coll)
	{
        if (coll.gameObject.CompareTag("Player") && (Time.time >= timeOut+coolDown)) {
			int i = 1;
			while(i != 5){
				realBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
				realBullet.GetComponent<Rigidbody2D>().velocity = new Vector2((10f+i)*distance,i-2);
				Destroy(realBullet, 6);
				i += 1;
			}
			timeOut = Time.time;
		}
    }
	void Update () {
		if(gameObject.transform.position.x <= -45){  
			fact.SetBool("isLeft", true);
			distance = 1;

		}else if(gameObject.transform.position.x >= 50){
			fact.SetBool("isLeft", false);
			distance = -1;
		}
		moveMent.velocity = new Vector2(12f*distance, 0);
	}

}
