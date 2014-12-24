using UnityEngine;
using System.Collections;

public class ElectIconInformation : MonoBehaviour {

	public string information ;		// ステージ名,条件,スコアのどれかが入る

	void Start () {
	
	}

	void Update () {
	
		this.guiText.text = "" + information;
	}
}
