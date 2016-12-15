using UnityEngine;
using System.Collections;

public class BlockScript : MonoBehaviour {
	public int hitsToKill = 1;
	public int points = 1;
	public int numberOfHits;
	private GameObject playerObject;
	public GameObject boom;
	public Transform thisTransform;
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
				boom = Instantiate(Resources.Load("Explosion", typeof(GameObject)) , thisTransform.position, thisTransform.rotation) as GameObject;
				int bonusIsset = Random.Range (0, 50);
				if (this.tag == "Bonus"&&bonusIsset >= 30) {
					GameObject bonusBlock = Instantiate (Resources.Load ("Bonus", typeof(GameObject)), thisTransform.position, thisTransform.rotation) as GameObject;
					bonusBlock.gameObject.GetComponent<ParticleSystem> ().startColor = new Color(0, 37/255f, 254/255f);;
					bonusBlock.gameObject.GetComponent<ParticleSystem>().Play();
					bonusBlock.gameObject.transform.Rotate (0.0f,-180.0f,0.0f); 
				}
				this.gameObject.SetActive(false);
			}
		}
	}
	void Start () {
		playerObject = GameObject.FindGameObjectsWithTag("Player")[0];
		thisTransform = this.transform;
	}

	void Update () {
	
	}
}
