using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	public int hitsToKill = 1;
	public int points = 1;
	public int numberOfHits;
	private GameObject playerObject;
	private GameObject parent;
	public void setHitsToKill(int value)
	{
		hitsToKill = value;
	}
	public void setPoints(int value)
	{
		points = value;
	}
	void OnCollisionEnter2D(Collision2D collision){
		if (collision.gameObject.tag == "Ball"){
			numberOfHits++;

			if (numberOfHits == hitsToKill){
				playerObject.SendMessage ("addPoints",points);
				Destroy (this.gameObject);
//				ParticleSystem.Play ();
			}
		}
	}
	void Start () {
		playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
		parent = this.parent;
	}

	void Update () {
	
	}
}
