using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveBoss : MonoBehaviour {

	public GameObject Bullet, realBullet;
	Transform post;
	Rigidbody2D moveMent;
	Animator fact;
	float timeOut = 0, coolDown = 5;

	private float jump = 0f;

	public int distance = -1;

	public float hpenemy = 500f;
	public float max = 500f;
	public Image img;
	private float widthImg;


	void Start () {
		post=GetComponent<Transform>();
		moveMent=GetComponent<Rigidbody2D>();
		fact=GetComponent<Animator>();
		widthImg =  img.GetComponent<RectTransform>().sizeDelta.x;

	}

	public void SeenPlayerAndFire(Collider2D coll)
	{	
		Debug.Log(Time.time >= timeOut+coolDown);
        if ((Time.time >= timeOut+coolDown)) {
			Debug.Log("boss fire");
			int i = 1;
			//Debug.Log("shoot");
			while(i != 5){
				realBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
				realBullet.GetComponent<Rigidbody2D>().velocity = new Vector2((10f+i)*distance,i-2);
				realBullet.GetComponent<Bullet>().setDamage(50);
				Debug.Log(realBullet.transform.position);
				Destroy(realBullet, 6);
				i += 1;
			}
			timeOut = Time.time;
		}
    }
	void Update () {
		if (hpenemy <= 0) {
			Destroy(gameObject);
        }
		img.GetComponent<RectTransform>().sizeDelta = new Vector2( (hpenemy / max) * widthImg,img.GetComponent<RectTransform>().sizeDelta.y );
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


	void FixedUpdate()
	{
		if (FindObjectOfType<triggerBoss>().isSeen && Time.time > timeOut + coolDown) {
			Debug.Log("boss fire");
			int i = 1;
			//Debug.Log("shoot");
			while(i != 5){

				realBullet = Instantiate(Bullet, gameObject.transform.position, Quaternion.identity);
				realBullet.GetComponent<Rigidbody2D>().velocity = new Vector2((10f+i)*distance,i-2);
				realBullet.GetComponent<Bullet>().setDamage(50);
				realBullet.GetComponent<Bullet>().player = gameObject;
				Debug.Log(realBullet.transform.position);
				Destroy(realBullet, 6);
				i += 1;
			}
			timeOut = Time.time;
		}
	}

	public void setHp(){

	}

}
