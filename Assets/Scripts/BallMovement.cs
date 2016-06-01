using UnityEngine;
using System.Collections;

public class BallMovement : MonoBehaviour {

	//Rigidbody rb;
	public float minVelocity = 0.1f;
	public float speed = 10f;
	public Vector3 movement;
	private Vector3 inNormal;

	private Vector3 startPosition;
	public bool Pause = true;

	void Awake () {

		movement = speed * transform.right * Time.deltaTime;
		startPosition = transform.position;

	}
	
	void FixedUpdate (){
		if (Pause) {
		}else{
			Vector3 move = movement * speed * Time.deltaTime;

			transform.Translate (move);
		}

	}

	void OnCollisionEnter(Collision collision){
		inNormal = new Vector3 (
			collision.contacts [0].point.x - transform.position.x , 
			0.0f, 
			collision.contacts [0].point.z - transform.position.z  
		);
		inNormal = inNormal.normalized;
		if (collision.gameObject.CompareTag ("Player")) {
			PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement> ();
			refreshMovement(inNormal, playerMovement.movement);
			return;
		};
		if (collision.gameObject.CompareTag ("Enemy")) {
			EnemyMovement enemyMovement = collision.gameObject.GetComponent<EnemyMovement> ();
			refreshMovement(inNormal, enemyMovement.movement);
			return;
		};
		refreshMovement(inNormal, new Vector3(0f,0f,0f));
	}

	void refreshMovement (Vector3 inNormal, Vector3 otherVector){
		Vector3 reflect = Vector3.Reflect (movement, inNormal);
		movement = reflect + otherVector ;
		movement = movement.normalized;
	}


	public void resetBall(){
		transform.position = startPosition;
		movement = transform.right;
	}
}



/*


		if (Physics.Raycast (transform.position, transform.right, 0.5f, reboundable)) {
			inNormal = transform.right;
		}
		if (Physics.Raycast (transform.position, - transform.right, 0.5f, reboundable)) {
			inNormal = - transform.right;
		}
		if (Physics.Raycast (transform.position, transform.forward, 0.5f, reboundable)) {
			inNormal = transform.forward; 
		}
		if (Physics.Raycast (transform.position, - transform.forward, 0.5f, reboundable)) {
			inNormal = - transform.forward; 
		}
		if (collision.gameObject.CompareTag ("Player")) {
			PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement> ();
			refreshMovement(inNormal, playerMovement.movement);
			return;
		}


 */


/*
	void FixedUpdate () {

		move = movement * Time.deltaTime * speed;
		transform.Translate (move);

	}

	void refreshMovement (Vector3 direction, Vector3 otherVector){
		Vector3 reflect = Vector3.Reflect (movement, direction);
		movement = reflect + otherVector ;
	}

	void OnCollisionEnter(Collision collision){
		//Debug.Log(rb.worldCenterOfMass );
		//Debug.Log (collision.contacts[0].point);
		Vector3 VectorBtoA = new Vector3 (
			collision.contacts[0].point.x - rb.worldCenterOfMass.x,
			0.0f,
			collision.contacts[0].point.z - rb.worldCenterOfMass.z
			);
		inNormal = VectorBtoA.normalized;

		if (collision.gameObject.CompareTag ("Player")) {
			PlayerMovement playerMovement = collision.gameObject.GetComponent<PlayerMovement> ();
			refreshMovement(inNormal, playerMovement.movement);
			return;
		}

		refreshMovement(inNormal, new Vector3(0f,0f,0f));


	}

 */
