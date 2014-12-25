using UnityEngine;
using System.Collections;

public class GuiTime : MonoBehaviour {

	private float timer ;		// 各ステージでの経過時間を記録

	void Start () {
	
	}

	void Update () {
	
		timer = Time.time;
		int drawTime = (int)timer;
		guiText.text = "TIME " + drawTime;
	}
}
