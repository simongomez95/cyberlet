using UnityEngine;
using System.Collections;

public class Unit : MonoBehaviour {
	GameObject player;
	public bool canDraw=false;
	public Vector3 targetOldPosition;
	public Transform target;
	public float speed = 20;
	Vector3[] path;
	int targetIndex;

	void Start() {
		player = GameObject.Find ("Player");
		target = player.GetComponent<Transform>();
		PathRequestManager.RequestPath(transform.position,target.position, OnPathFound);
		targetOldPosition = target.position;
	}
	void Update(){
		if (Vector3.Distance(targetOldPosition, target.position) > 2)
		{
			PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
			targetOldPosition = target.position;
		} 
	}

	void FixedUpdate() {
		float z = Mathf.Atan2((target.transform.position.y - transform.position.y),
		                      (target.transform.position.x - transform.position.x)) * Mathf.Rad2Deg - 90;
		transform.eulerAngles = new Vector3(0,0, z);
	}

	public void OnPathFound(Vector3[] newPath, bool pathSuccessful) {
		if (pathSuccessful) {
			path = newPath;
			StopCoroutine("FollowPath");
			StartCoroutine("FollowPath");
		}
	}

	void OnCollisionEnter2D(Collision2D other) {
		if (other.gameObject.tag == "Player" || other.gameObject.tag == "Bala") {
			StopCoroutine("FollowPath");
			Application.LoadLevel ("GameOver");
			//Destroy(other.gameObject);

		}
	}

	IEnumerator FollowPath() {
		Vector3 currentWaypoint = path[0];

		while (true) {
			if (transform.position == currentWaypoint) {
				targetIndex ++;
				if (targetIndex >= path.Length) {
					targetIndex = 0;
					path = new Vector3[0];
					NewPath();
					yield break;
				}
				currentWaypoint = path[targetIndex];
			}

			transform.position = Vector3.MoveTowards(transform.position,currentWaypoint,speed * Time.deltaTime);
			yield return null;

		}
	}

	public void OnDrawGizmos() {
		if (canDraw) {
			if (path != null) {
				for (int i = targetIndex; i < path.Length; i ++) {
					Gizmos.color = Color.black;
					Gizmos.DrawCube (path [i], Vector3.one);

					if (i == targetIndex) {
						Gizmos.DrawLine (transform.position, path [i]);
					} else {
						Gizmos.DrawLine (path [i - 1], path [i]);
					}
				}
			}
		}
	}
	public void NewPath()
	{
		PathRequestManager.RequestPath(transform.position, target.position, OnPathFound);
	}
}
