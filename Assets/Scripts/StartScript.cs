using UnityEngine;
using System.Collections;

public class StartScript : MonoBehaviour {
	// Use this for initialization
	void Start () {
		Object fromPrefab = Resources.Load("FirstBlock");
		for (int j = 0; j < 5; j++) {
			for (int i = 0; i < 15; i++) {
				var isTrue = (int)Random.Range (1, 10);
				if (isTrue < 8) {
					Instantiate (fromPrefab, new Vector2 (10.0f - i*1.3f, 1.6f + j), Quaternion.identity);
				}
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
