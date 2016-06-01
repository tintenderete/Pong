using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {


	public float speed = 10f;
	public float movMin = 0f ;
	public float movMax = 0f;
	public Vector3 movement;
	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

		float h = Input.GetAxisRaw ("Vertical");
		movement = h * speed * transform.forward * Time.deltaTime;
		transform.Translate (movement);
		transform.position = new Vector3 (transform.position.x, transform.position.y,
		                                  Mathf.Clamp (transform.position.z, movMin, movMax));

	}
}
