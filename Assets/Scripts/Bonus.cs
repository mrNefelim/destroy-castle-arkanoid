using UnityEngine;
using System.Collections;

public class Bonus : MonoBehaviour {
	int bonusIsTrue;
	GameObject player;
	void OnTriggerEnter2D(Collider2D thisPlayer) {
		if (thisPlayer.gameObject.tag == "Player") {
			player = thisPlayer.gameObject;
			bonusIsTrue  = Random.Range (1, 3);
			switch(bonusIsTrue)
			{
				case 1:
					player.transform.localScale += new Vector3 (player.transform.localScale.x * 0.5f, 0.0f, 0.0f);
					break;
				case 2:
					player.gameObject.GetComponent<PlayerScript>().ballStick = true;
					break;
				default:
					break;
			}
			this.gameObject.GetComponent<Collider2D>().enabled = false;
			this.gameObject.GetComponent<SpriteRenderer>().enabled = false;
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.y < -10f) {
			Destroy (this.gameObject);
		}
	}
}
