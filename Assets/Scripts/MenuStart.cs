using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class MenuStart : MonoBehaviour {

	public Canvas points;
	public Canvas menu;
	public Button startGame; 
	private GameObject Ball;
	private BallMovement ballMovemenet;


	// Use this for initialization
	void Start () {
		points.enabled = false;
		Ball = GameObject.FindGameObjectWithTag ("Ball");
		ballMovemenet = Ball.GetComponent<BallMovement>(); 
	}
	
	// Update is called once per frame

	public void StartGame(){
		menu.enabled = false;
		points.enabled = true;
		ballMovemenet.Pause = false;
	}
}
