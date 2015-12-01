using UnityEngine;
using System.Collections;

public class Pared : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.tag == "Bala") 	
			Destroy(other.gameObject);
		//Destroy (GetComponent<GameObject> ());
	}

}
