using UnityEngine;
using System.Collections;

public class Bala : MonoBehaviour {

	public int speed;

	void Start(){
		GetComponent<Rigidbody2D> ().AddForce (gameObject.transform.up * speed);

	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bala" || other.gameObject.tag == "Terrain") {
			return;
		}
		Destroy(other.gameObject);
	}


}
