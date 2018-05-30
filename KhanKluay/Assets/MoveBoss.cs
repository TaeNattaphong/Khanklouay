using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBoss : MonoBehaviour {

	public GameObject Bullet, realBullet;
	Transform post;
	Rigidbody2D moveMent;
	Animator fact;

	private float jump = 0f;

	private int distance = -1;

	void Start () {
		post=GetComponent<Transform>();
		moveMent=GetComponent<Rigidbody2D>();

	}

	void OnTriggerEnter2D(Collider2D coll)
	{
        if (coll.gameObject.CompareTag("Player")) {
			int i = 1;
			while(i != 5){
				realBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
				realBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(1f, 0f);
				Destroy(realBullet, 5);
				i += 1;
			}
		}
    }


	void Update () {
		if(gameObject.transform.position.x <= -45){  
			distance = 1;
		}else if(gameObject.transform.position.x >= 50){
			distance = -1;
		}
		moveMent.velocity = new Vector2(12f*distance, 0);
	}

}
