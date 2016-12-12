using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerScript : MonoBehaviour {
	public float boundary;
	public float playerVelocity;
	private Vector3 playerPosition;
	public GameObject ballObject;
	public GameObject fire;
	private int playerLives;
	private int playerPoints;
	public GameObject guiLives;
	public GameObject guiScores;
	private Vector3 mousepoint;
	void addPoints(int points){
		playerPoints += points;
		if (playerPoints > 100) {
			fire.SetActive (true);
			fire.SendMessage ("upFire", 0.02f);
		}
	}
	void TakeLife(){
		playerLives--;
	}
	void OnGUI(){
		guiLives.GetComponent<Text> ().text = playerLives.ToString();
		guiScores.GetComponent<Text> ().text = playerPoints.ToString();
		PlayerPrefs.SetInt("playerPoints", playerPoints);
	}
	void Start () {
		playerPosition = gameObject.transform.position;
		playerLives = 3;
		playerPoints = 0;
		playerPoints = PlayerPrefs.GetInt ("playerPoints");
		fire.SetActive (false);
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
