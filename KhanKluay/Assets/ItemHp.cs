using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemHp : MonoBehaviour {

	
	public AudioClip sound;
   	public AudioSource source;

	Collider2D c;
	void Start () {
		c = GetComponent<Collider2D>();
		c.isTrigger = true;
		source = GetComponent<AudioSource>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player"){
			ControlPlayer.hpplayer += 20;
			
			new Sound().SoundFX(sound, gameObject.transform.position);
			Destroy(gameObject);
		
		}
	}
}
