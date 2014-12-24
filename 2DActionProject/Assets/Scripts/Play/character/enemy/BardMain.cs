using UnityEngine;
using System.Collections;

public class BardMain : MonoBehaviour {
	
	private BardController controller;	// コントローラー

	void Start () {
	
		controller = GetComponent<BardController> ();
	}

	void Update () {

		controller.Work ();				// 一連の処理を内部でしてくれる
	
	}
}
