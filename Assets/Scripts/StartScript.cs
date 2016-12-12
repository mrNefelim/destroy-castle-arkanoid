using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StartScript : MonoBehaviour {
	public int lineCount = 5;
	public int columnsCount = 12;
	List<int> blocksCount = new List<int>();
	[System.Serializable]
	public class levelObjects{
		public GameObject fromPrefab;
		public int fromPrefabCount = 10;
		public int hitsToKill = 1;
		public int points = 10;
	}
	public levelObjects[] newLevelObjects;
	void Start () {
		for (int j = 0; j < newLevelObjects.Length; j++) {
			for (int i = 0; i < newLevelObjects[j].fromPrefabCount; i++) {
				blocksCount.Add (j);
			}
		}
		if (columnsCount * lineCount > blocksCount.Count) {
			columnsCount = blocksCount.Count / lineCount;
			if(columnsCount < 1){columnsCount = 1;}
		}
		if (columnsCount * lineCount > blocksCount.Count) {
			lineCount = blocksCount.Count / columnsCount;
			if(lineCount < 1){lineCount = 1;}
		}
		for (int j = 0; j < lineCount; j++) {
			for (int i = 0; i < columnsCount; i++) {
			//	if (isTrue != columnsCount / 10) { // Empty blocks with 10% chance
					int thisNumberBlock = (int)Random.Range (0, blocksCount.Count);
					GameObject thisBlock = Instantiate (newLevelObjects [blocksCount [thisNumberBlock]].fromPrefab, new Vector2 (10.0f - i * 1.3f, 1.6f + j), Quaternion.identity) as GameObject;
					thisBlock.SendMessage("setHitsToKill",newLevelObjects [blocksCount [thisNumberBlock]].hitsToKill);
					thisBlock.SendMessage("setPoints",newLevelObjects [blocksCount [thisNumberBlock]].points);
					blocksCount.RemoveAt (thisNumberBlock);
			//	}
			}
		}
	}	
	// Update is called once per frame
	void Update () {
	
	}
}
