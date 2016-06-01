using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameControl : MonoBehaviour {

	private GameObject Ball;
	private BallMovement ballMovement;
	private float playerCount = 0f;
	private float computerCount = 0f;

	public Text playerText;
	public Text computerText;
	public float limitPith = 15f;
	

	// Use this for initialization
	void Start () {
		Ball = GameObject.FindGameObjectWithTag("Ball");
		ballMovement = Ball.GetComponent<BallMovement> ();
		//playerText = GetComponent <Text> ();
		//computerText = GetComponent <Text> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Ball.transform.position.x > limitPith) {

			computerCount = computerCount + 1;
			computerText.text = "Computer: " + computerCount;
			ballMovement.resetBall();
		}
		if (Ball.transform.position.x < -limitPith) {

			playerCount = playerCount + 1;
			playerText.text = "player: " + playerCount;
			ballMovement.resetBall();
		}

	}
}
