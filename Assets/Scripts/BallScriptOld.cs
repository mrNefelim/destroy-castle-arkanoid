/*using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {
	private bool ballIsActive;
	private Vector3 ballPosition;
	private Vector2 ballInitialForce;
	public GameObject playerObject;

	private Vector2 ballAddForce;

	private float velocityx;
	private float velocityy;
	private float velocityxOld;
	private float velocityyOld;
	// Use this for initialization
	void OnCollisionEnter2D(Collision2D collision){
		velocityx = GetComponent<Rigidbody2D> ().velocity.x;
		velocityy = GetComponent<Rigidbody2D> ().velocity.y;
		if(velocityx!=0.0f&&velocityy!=0.0f){
			velocityxOld = velocityx;
			velocityyOld = velocityy;
		}
		if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "BarTop") {
			if (velocityx < 0.0f) {
				velocityx = -30.0f;
			} else if (velocityx > 0.0f) {
				velocityx = 30.0f;
			} else if (velocityxOld > 0.0f) {
				velocityx = velocityxOld + 10.0f;
			} else if (velocityxOld < 0.0f) {
				velocityx = velocityxOld - 10.0f;
			} else {
				velocityx = 50.0f;
			}
		} else {
			if (velocityy < 0.0f) {
				velocityy = -30.0f;
			} else if (velocityy > 0.0f) {
				velocityy = 30.0f;
			} else if (velocityyOld > 0.0f) {
				velocityy = velocityyOld + 10.0f;
			} else if (velocityyOld > 0.0f) {
				velocityy = velocityyOld - 10.0f;
			} else {
				velocityy = 50.0f;
			}
		}
		if ((float)Mathf.Abs (velocityx) < 10) {
			velocityx = (velocityx+5.0f) * 2;
		}
		if ((float)Mathf.Abs (velocityy) < 10) {
			velocityy = (velocityy+5.0f) * 2;
		}
		if ((float)Mathf.Abs (velocityx) > 15) {
			velocityx -= velocityx/2;
			velocityy = velocityy * 3;
		}
		if ((float)Mathf.Abs (velocityy) > 15) {
			velocityy -= velocityy/2;
			velocityx = velocityx * 3;
		}
		//velocityx = velocityx + 0.5f;
		//velocityy = velocityy + 0.5f;
		ballAddForce = new Vector2 (velocityx,velocityy);
		GetComponent<Rigidbody2D>().AddForce(ballAddForce);
		//Debug.Log ( GetComponent<Rigidbody2D> ().velocity.magnitude);
		Debug.Log (ballAddForce + "-" + GetComponent<Rigidbody2D> ().velocity + "---------------------------");
	}
	void Start () {
		// создаем силу
		ballInitialForce = new Vector2 (50.0f,100.0f);

		// переводим в неактивное состояние
		ballIsActive = false;

		// запоминаем положение
		ballPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown ("Jump") == true) {
			// проверка состояния
			if (!ballIsActive){
				// сброс всех сил
				GetComponent<Rigidbody2D>().isKinematic = false;
				// применим силу
				GetComponent<Rigidbody2D>().AddForce(ballInitialForce);
				// зададим активное состояние
				ballIsActive = !ballIsActive;
			}
		}
		if (!ballIsActive && playerObject != null){
			// задаем новую позицию шарика
			ballPosition.x = playerObject.transform.position.x;

			// устанавливаем позицию шара
			transform.position = ballPosition;
		}
		if (ballIsActive && transform.position.y < -2) {
			ballIsActive = !ballIsActive;
			ballPosition.x = playerObject.transform.position.x;
			ballPosition.y = -0.83f;
			transform.position = ballPosition;
			GetComponent<Rigidbody2D>().isKinematic = true;
		}
	}
}
*/