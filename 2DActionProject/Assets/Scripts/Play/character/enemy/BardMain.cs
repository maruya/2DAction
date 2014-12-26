using UnityEngine;
using System.Collections;

public class BardMain : MonoBehaviour {
	
	private BardController controller;

	void Start () {
	
		controller = GetComponent<BardController> ();
	}

	void Update () {

		controller.Work ();		// 敵の挙動から処理までを操作
	
	}
}
