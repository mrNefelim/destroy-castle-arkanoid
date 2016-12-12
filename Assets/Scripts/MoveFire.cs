using UnityEngine;
using System.Collections;

public class MoveFire : MonoBehaviour {
	GameObject fire;
	GameObject fireDubl;
	private bool fireDublIsset = false;
	private bool delayx = false;
	private bool delayy = false;
	private bool upFireTrue = false;
	float up = 0.0f; 
	public float index;
	Vector2 old_pos;
	Vector2 new_pos;
	public void upFire(float upValue)
	{
		upFireTrue = true;
		up = upValue;
	}
	void Start () {
		old_pos = this.transform.position;
		new_pos = this.transform.position;
	}
	void Update () {
		new_pos = this.transform.position;
		/////// X
		if (new_pos.x > old_pos.x + index) {
			delayx = true;
		} 
		if (new_pos.x < old_pos.x - index) {
			delayx = false;
		}
		if(delayx == false)
		{
			new_pos.x += index * Time.deltaTime * 4.0f;
		} else {
			new_pos.x -= index * Time.deltaTime * 4.0f;
		}
		/////// Y
		if (new_pos.y > old_pos.y + 0.2f) {
			delayy = true;
		} 
		if (new_pos.y < old_pos.y - 0.2f) {
			delayy = false;
		}
		if(delayy == false)
		{
			new_pos.y += 0.02f * Time.deltaTime * 4.0f;
		} else {
			new_pos.y -= 0.02f * Time.deltaTime * 4.0f;
		}
		if (upFireTrue == true) {
			old_pos = new Vector2 (old_pos.x, old_pos.y + up);
			new_pos = new Vector2 (new_pos.x, new_pos.y + up);
			upFireTrue = false;
			if (new_pos.y > 0.25f&&fireDublIsset == false) {
				fireDubl = Instantiate(this.gameObject, new_pos, this.transform.rotation) as GameObject;
				fireDubl.transform.SetParent (this.transform.parent);
				fireDubl.transform.localScale = new Vector2(0.07f,0.07f);
				fireDublIsset = true;
			}
		}
		///////
		this.transform.position = new Vector2 (new_pos.x,new_pos.y);
	}
}
