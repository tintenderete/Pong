using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	public float speed = 10;
	[HideInInspector]
	public Vector3 movement;
	public float movMin = 0f ;
	public float movMax = 0f;

	// Use this for initialization
	void Start () {
		movement = new Vector3(0f,0f,0f);
	}

	void FixedUpdate(){

		movement = movement * speed * Time.deltaTime;
		transform.Translate(movement);

		transform.position = new Vector3 (transform.position.x, transform.position.y,
		                                  Mathf.Clamp (transform.position.z, movMin, movMax));
	}

	public void refreshMovement(Vector3 newMovement){

		Vector3 v = new Vector3 (
			0.0f,
			0.0f,
			newMovement.z - transform.position.z
			);

		movement = v.normalized;
	}



}
