using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	public int hitsToKill;
	public int points;
	public int numberOfHits;
	private GameObject playerObject;
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Ball"){
			numberOfHits++;

			if (numberOfHits == hitsToKill){
				playerObject.SendMessage ("addPoints",points);
				Destroy(this.gameObject);
			}
		}
	}
	void Start () {
		playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
	}

	void Update () {
	
	}
}
