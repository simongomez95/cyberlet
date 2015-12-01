using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {

	public float speed;
	public GameObject bullet;
	float movingSpeed = 0;
	Animator anim;
	bool allowFire = true;



	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	IEnumerator Fire(){
		allowFire = false;
		Instantiate(bullet, transform.position, transform.rotation);
		yield return new WaitForSeconds (0.5f);
		allowFire = true;
	}

	void Update()
	{
		if (Input.GetButton("Fire1")&&allowFire==true) {
			anim.SetTrigger("Attack");
			StartCoroutine(Fire ());
		}

		if (Input.GetAxis ("Vertical") != 0 || Input.GetAxis ("Horizontal") != 0) {
			anim.SetBool ("isMoving", true);			
		} else {
			anim.SetBool("isMoving", false);
		}
	}

	void OnTriggerEnter2D() {

		if (GameObject.FindGameObjectsWithTag ("Spawner").Length > 0) {
			return;
		}
		Application.LoadLevel(Application.loadedLevel + 1);
	}

	void FixedUpdate()
	{

		//Rotacion
		var mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Quaternion rot = Quaternion.LookRotation (transform.position - mousePosition, Vector3.forward);

		transform.rotation = rot;


		//limitar la rotacion a ejes XY
		transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
		GetComponent<Rigidbody2D>().angularVelocity = 0;

		//Movimiento en el mapa
		float input_y = Input.GetAxis ("Vertical");
		float input_x = Input.GetAxis ("Horizontal");

		transform.position = new Vector3(transform.position.x + input_x * speed, transform.position.y + input_y * speed, transform.position.z);


	}
}
