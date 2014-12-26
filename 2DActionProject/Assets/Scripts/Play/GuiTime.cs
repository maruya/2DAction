using UnityEngine;
using System.Collections;

public class GuiTime : MonoBehaviour {
	
	public float timer ;				// 各ステージでの経過時間を記録
	

	void Update () {
	
		timer = Time.time;
		guiText.text = "TIME " + (int)timer;
	}
}
