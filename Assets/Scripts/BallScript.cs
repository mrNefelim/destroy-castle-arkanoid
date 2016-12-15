using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	public bool ballIsActive;
	private Vector3 ballPosition;
	private Vector2 ballInitialForce;
	public GameObject playerObject;

	private Vector2 ballAddForce;
	private float speedx = 50.0f;
	private float speedy = 100.0f;
	private float velocityx;
	private float velocityy;
	private float velocityxOld;
	private float velocityyOld;

	// Use this for initialization
	void OnCollisionEnter2D(Collision2D collision){
		velocityx = GetComponent<Rigidbody2D> ().velocity.x;
		velocityy = GetComponent<Rigidbody2D> ().velocity.y;
		if (collision.gameObject.tag == "BarRight") {
			velocityx = -speedx;
		} else if (collision.gameObject.tag == "BarLeft") {
			velocityx = speedx;
		} else if (collision.gameObject.tag == "Block") {
			if (velocityx > 0) {
				velocityx = speedx;
			} else if (velocityx < 0) {
				velocityx = -speedx;
			} else {
				float blockPosX = collision.gameObject.transform.position.x;
				float ballPosX = gameObject.transform.position.x;
				if ((blockPosX - ballPosX) < 0) {
					velocityx = speedx;
				} else {
					velocityx = -speedx;
				}
			}
		} else {
			if (velocityx > 0) {
				velocityx = speedx;
			} else if (velocityx < 0) {
				velocityx = -speedx;
			} else if (velocityxOld > 0) {
				velocityx = speedx;
			} else if (velocityxOld < 0) {
				velocityx = -speedx;
			} else {
				velocityx = speedx;
			}
		}
		if (collision.gameObject.tag == "Player") {
			velocityy = speedy;
		} else if (collision.gameObject.tag == "BarTop") {
			velocityy = -speedy;
		} else if (collision.gameObject.tag == "Block") {
			if (velocityy > 0) {
				velocityy = speedy;
			} else if (velocityy < 0) {
				velocityy = -speedy;
			} else {
				float blockPosY = collision.gameObject.transform.position.y;
				float ballPosY = gameObject.transform.position.y;
				if ((blockPosY - ballPosY) < 0) {
					velocityy = speedy;
				} else {
					velocityy = -speedy;
				}
			}
		} else {
			if (velocityy > 0) {
				velocityy = speedy;
			} else if (velocityy < 0) {
				velocityy = -speedy;
			} else if (velocityyOld > 0) {
				velocityy = speedy;
			} else if (velocityyOld > 0) {
				velocityy = -speedy;
			} else {
				velocityy = speedy;
			}
		}
		velocityxOld = velocityx;
		velocityyOld = velocityy;
		ballAddForce = new Vector2 (velocityx,velocityy);
		GetComponent<Rigidbody2D>().AddForce(ballAddForce);
	}
	void Start () {
		ballInitialForce = new Vector2 (10.0f,speedy);
		ballIsActive = false;
		ballPosition = transform.position;
	}

	void Update () {
		if (Input.GetButtonDown ("Jump") == true) {
			if (!ballIsActive){
				GetComponent<Rigidbody2D>().isKinematic = false;
				GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
				ballIsActive = !ballIsActive;
			}
		}
		if (!ballIsActive && playerObject != null){
			ballPosition.x = playerObject.transform.position.x;
			transform.position = ballPosition;
		}
		if (ballIsActive && transform.position.y < -6) {
			ballIsActive = !ballIsActive;
			ballPosition.x = playerObject.transform.position.x;
			ballPosition.y = -5.23f;
			transform.position = ballPosition;
			GetComponent<Rigidbody2D>().isKinematic = true;
			playerObject.SendMessage("TakeLife");
		}
	}
}
