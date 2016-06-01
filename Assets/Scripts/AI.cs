using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {

	[Range(0.0f,1.0f)]
	public float rangeError = 0;
	private GameObject Enemy;
	private EnemyMovement enemyMovement;
	private BallMovement ballMovemenet;
	private GameObject Ball;
	private int layerMaskWall;
	private Ray shootRay;
	private RaycastHit shootHit;
	private Vector3 nextMovement;
	private Vector3 nextPoint = new Vector3(0f,0f,0f);
	private Vector3 hypotenuse;
	private Vector3 nextRebound = new Vector3(0f,0f,0f);

	private float count;
	// Use this for initialization
	void Start () {

		Ball = GameObject.FindGameObjectWithTag ("Ball");
		ballMovemenet = Ball.GetComponent<BallMovement> ();

		Enemy = GameObject.FindGameObjectWithTag ("Enemy");
		enemyMovement = Enemy.GetComponent<EnemyMovement> ();

		layerMaskWall = LayerMask.GetMask("AI Wall");


	}
	

	void Update () {
		if (ballMovemenet.movement.x < 0) {
			shootRay.origin = Ball.transform.position;
			shootRay.direction = ballMovemenet.movement;
			getVectorMovement ();
			//Debug.Log(count);
			count = 0;
		}


	
	}

	void getVectorMovement(){
		count ++;
		if(Physics.Raycast (shootRay.origin, shootRay.direction, out shootHit, 1000f, layerMaskWall)){
			if(shootHit.collider.CompareTag("AI Final Point")){

				enemyMovement.refreshMovement(shootHit.point);
				shootRay.origin = Ball.transform.position;
				shootRay.direction = ballMovemenet.movement;

			}else{

				nextPoint =  shootHit.point;

				getHypotenuse(nextPoint, ballMovemenet.movement);
				getNextRebound(hypotenuse, ballMovemenet.movement);

				/// RANDOM //////
				nextPoint = new Vector3 (
					nextPoint.x * (1 + Random.Range(-rangeError, rangeError)),
					0.0f,
					nextPoint.z * (1 + Random.Range(-rangeError, rangeError))
					);
				nextRebound = new Vector3 (
					nextRebound.x * (1 + Random.Range(-rangeError, 0.0f)),
					0.0f,
					nextRebound.z * (1 + Random.Range(-rangeError, rangeError))
					);
				/// END RANDOM ////

				shootRay.origin = nextPoint;
				shootRay.direction = nextRebound;

				getVectorMovement ();

			}
		};



	}



	void getHypotenuse(Vector3 lastPoint, Vector3 positionBall){

		Vector3 aux = new Vector3 (lastPoint.x, lastPoint.y, positionBall.z); 

		Vector3 h = new Vector3 (
			lastPoint.x - aux.x ,
			lastPoint.y - aux.y,
			lastPoint.z - aux.z
			);


		hypotenuse =  h.normalized;

	}

	void getNextRebound(Vector3 inNormal, Vector3 movement){

		nextRebound = Vector3.Reflect (movement, inNormal);

	}
	
}









