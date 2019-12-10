using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour {
	private float speed = -12;
	private float deadLine = -10;
	public AudioClip Block;
	AudioSource audioSource;

	// Use this for initialization
	void Start () {
		this.audioSource = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate (this.speed * Time.deltaTime, 0, 0);

		if (transform.position.x < this.deadLine) {
			Destroy (gameObject);
		}
	}

	void OnCollisionEnter2D (Collision2D collision){
		if (collision.gameObject.tag == "groundTag" || collision.gameObject.tag == "CubeTag") {
			this.audioSource.PlayOneShot (Block);
		}
		if (collision.gameObject.tag == "UnityChanTag") {
			this.audioSource.volume = 0;
		}
	}
}