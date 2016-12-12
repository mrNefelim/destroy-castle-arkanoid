using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class StartScript : MonoBehaviour {
	public int lineCount = 5;
	public int columnsCount = 12;
	public int emptyCount = 10;
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
			int thisEmptyCount = emptyCount / lineCount;
			for (int i = 0; i < columnsCount; i++) {
				int thisNumberBlock = (int)Random.Range (0, blocksCount.Count);
				if (Random.Range (0, thisEmptyCount) > thisEmptyCount / 3) {
					i++;
					thisEmptyCount--;
				}
				Vector2 thisVector = new Vector2 ((1.3f * columnsCount/2) - i * 1.3f, 1.6f + j);
				GameObject thisBlock = Instantiate (newLevelObjects [blocksCount [thisNumberBlock]].fromPrefab, thisVector, Quaternion.identity) as GameObject;
				thisBlock.SendMessage("setHitsToKill",newLevelObjects [blocksCount [thisNumberBlock]].hitsToKill);
				thisBlock.SendMessage("setPoints",newLevelObjects [blocksCount [thisNumberBlock]].points);
				blocksCount.RemoveAt (thisNumberBlock);
			}
		}
	}	
	void Update () {
	
	}
}
