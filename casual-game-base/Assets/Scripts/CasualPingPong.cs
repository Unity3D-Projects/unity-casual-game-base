using UnityEngine;
using System.Collections;

public class CasualPingPong : MonoBehaviour {
	// Use this for initialization
	private GameObject paddle1, paddle2;
	private Vector2 leftForce, rightForce;
	public float speed = 0.4f;
	void Start () {
		GameObject ball = GameObject.Find ("ball");
		paddle1 = GameObject.Find ("paddle1");
		paddle2 = GameObject.Find ("paddle2");
		leftForce = new Vector2 (-speed, 0);
		rightForce = new Vector2 (speed, 0);

		Vector2 vForce = CasualBall.INITIAL_SPEED; //TODO: Random
		ball.GetComponent<Rigidbody2D> ().AddForce(vForce);
	}
	
	// Update is called once per frame
	void Update () {
//		bool p1Pressed = Input.GetButton (Constants.INPUT.HORIZONTAL);
		//		bool p2Pressed = Input.GetButton (Constants.INPUT.HORIZONTAL);
		bool left1 = Input.GetKey (KeyCode.A) ;
		bool right1 = Input.GetKey (KeyCode.D) ;
		
		bool left2 = Input.GetKey (KeyCode.LeftArrow) ;
		bool right2 = Input.GetKey (KeyCode.RightArrow) ;
		
		if(left1){
			moveLeft(paddle1);
		} else if(right1){
			moveRight(paddle1);
		}
		if(left2){
			moveLeft(paddle2);
		} else if(right2){
			moveRight(paddle2);
		}
	}
	private void move(GameObject paddle, Vector2 force){
		Rigidbody2D rigidBody = paddle.GetComponent<Rigidbody2D> ();
		Vector2 position = rigidBody.position;
		Vector2 newPosition = position + force;

		rigidBody.MovePosition (newPosition);
	}
	private void moveRight(GameObject paddle){
		this.move (paddle, rightForce);
	}
	private void moveLeft(GameObject paddle){
		this.move (paddle, leftForce);
	}
}
