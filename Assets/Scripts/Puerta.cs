using UnityEngine;
using System.Collections;

public class Puerta : MonoBehaviour {

	public Transform player;
	public float distanceLimit;
	Animator anim;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	
	}
	
	// Update is called once per frame
	void Update () {

		if (Vector3.Distance (this.transform.position, player.transform.position) < distanceLimit) {
			anim.SetTrigger ("playerCercano");
		}
	
	}
}
