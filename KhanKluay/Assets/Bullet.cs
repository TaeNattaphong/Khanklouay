using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {

	// Use this for initialization
	public GameObject player;
	private float damage;

	public void setDamage(float damage){
		this.damage = damage;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Item") {

		}
		else if (other.tag == "enemy" || (other.tag == "Player" && player.tag != "Player")) {	
			other.gameObject.GetComponent<enemy>().hpenemy -= damage;
			Debug.Log("fire");
			Destroy(gameObject);
		}
		else if(other.gameObject != player && other.gameObject.tag != "checkFound"){
			Debug.Log("fire2");
			Destroy(gameObject);

			//Debug.Log("fire enemy");
		}
	}
}

/*public class Bullet : NetworkBehaviour {

    [SyncVar]
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject != player)
            Destroy(gameObject);
    }
}*/
