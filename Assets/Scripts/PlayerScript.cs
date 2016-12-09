using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float boundary;
	public float playerVelocity;
	private Vector3 playerPosition;
	public GameObject ballObject;
	private int playerLives;
	private int playerPoints;
	public GameObject PowerActive;
	private Vector3 mousepoint;
	void addPoints(int points){
		playerPoints += points;
	}
	void TakeLife(){
		playerLives--;
	}
	void OnGUI(){
		GUI.Label (new Rect(5.0f,3.0f,200.0f,200.0f),"Live's: " + playerLives + "  Score: " + playerPoints);
	}
	void Start () {
		playerPosition = gameObject.transform.position;
		playerLives = 3;
		playerPoints = 0;

		//PowerActive = GameObject.FindGameObjectsWithTag("PowerActive")[0];
		//PowerActive.transform.localScale = new Vector2(0.6f,0.1f);
		//Debug.Log(PowerActive.transform.localScale.y);
	}
	void Update () {
		if (Input.GetAxis ("Horizontal") != 0) {
			playerPosition.x += Input.GetAxis ("Horizontal") * playerVelocity;
		}
		if (Input.GetAxis ("Mouse X") != 0) {
			mousepoint = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			playerPosition.x = mousepoint.x;
		}
		if (Input.GetKeyDown(KeyCode.Escape)){
			Application.Quit();
		}
		if (playerPosition.x < -boundary) {
			playerPosition.x = -boundary;
		}
		if (playerPosition.x > boundary) {
			playerPosition.x = boundary;
		} 
		transform.position = playerPosition;

	}
}
