using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Bullet : MonoBehaviour {

	// Use this for initialization
	public GameObject player;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Item") {

		}
		else if (other.tag == "enemy") {
			enemy.hp -= 30;
			Destroy(gameObject);
		}
		else if(other.gameObject != player){
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
