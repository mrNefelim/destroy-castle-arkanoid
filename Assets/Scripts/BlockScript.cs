using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	public int hitsToKill = 1;
	public int points = 1;
	public int numberOfHits;
	private GameObject playerObject;
	public ParticleSystem thisParticle;
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
				this.GetComponent<SpriteRenderer> ().enabled = false;
				this.GetComponent<BoxCollider2D> ().enabled = false;
				this.GetComponent<ParticleSystem>().Play (true);
				if (!this.GetComponent<ParticleSystem>().IsAlive ()) {
					Destroy (this.gameObject);
				}
				//
			}
		}
	}
	void Start () {
		playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
	}

	void Update () {
	
	}
}
