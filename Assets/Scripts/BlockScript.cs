using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	public int hitsToKill = 1;
	public int points = 1;
	public int numberOfHits;
	private GameObject playerObject;
	public GameObject boom;
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
				boom = Instantiate(Resources.Load("Explosion", typeof(GameObject)) , this.transform.position, this.transform.rotation) as GameObject;
				int bonusIsset = Random.Range (0, 50);
				if (this.tag == "Bonus"&&bonusIsset >= 30) {
					GameObject bonusBlock = Instantiate (Resources.Load ("Bonus", typeof(GameObject)), this.transform.position, this.transform.rotation) as GameObject;
				}
				this.gameObject.SetActive(false);
			}
		}
	}
	void Start () {
		playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
	}

	void Update () {
	
	}
}
