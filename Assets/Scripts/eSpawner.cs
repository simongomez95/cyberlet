using UnityEngine;
using System.Collections;

public class eSpawner : MonoBehaviour {
	public GameObject[] obj;
	public float max = 1f;
	public float min = 0;
	void Start () {
		Spawn ();
	}

	void Spawn () {
		Instantiate (obj [0], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (min, max));
	}
}
