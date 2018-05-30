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
			realBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
            realBullet.GetComponent<Rigidbody2D>().velocity = new Vector2(0f, 50f);
		}
    }

	// void OnTriggerExit2D(Collider2D coll)
	// {
	// 	if (coll.gameObject.CompareTag("Player")) {
	// 		// moveMent.velocity = new Vector2(0f, 30f);
	// 		jump = 0f;
	// 		Debug.Log("jump");
	// 	}
	// }
	void Update () {
		if(gameObject.transform.position.x <= -45){   // isRight => check animation that onside?
			// fact.SetBool("isRight",true);
			distance = 1;
		}else if(gameObject.transform.position.x >= 50){
			// fact.SetBool("isRight",false);
			distance = -1;
		}
		Debug.Log("move");
		moveMent.velocity = new Vector2(12f*distance, jump);
	}

}
