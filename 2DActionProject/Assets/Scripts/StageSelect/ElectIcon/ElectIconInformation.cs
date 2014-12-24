using UnityEngine;
using System.Collections;

public class ElectIconInformation : MonoBehaviour {

	public string information ;		// ステージ名,条件,スコアのどれかが入る

	void Start () {
	
	}

	void Update () {
	
	}

	public void DrawInfo()
	{
		Debug.Log ("Hit");
		this.guiText.text = "" + information;
	}
	
}
